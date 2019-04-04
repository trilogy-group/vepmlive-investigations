using System;
using System.Collections.Generic;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Fakes;
using System.Web.SessionState.Fakes;
using CADataCache;
using CADataCache.Fakes;
using CostDataValues;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using PortfolioEngineCore.PortfolioItems;
using PortfolioEngineCore.PortfolioItems.Fakes;
using Shouldly;
using WorkEnginePPM.Fakes;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass, ExcludeFromCodeCoverage]
    public class CostAnalyzerTests
    {
        private IDisposable _shimContext;
        private CostAnalyzer _testObject;

        private static readonly Guid DummySiteGuid = new Guid("9410247d-c831-4093-9748-f4fe7495bd78");
        private static readonly DateTime DummyDateTime = new DateTime(2018, 6, 15, 0, 0, 0, DateTimeKind.Utc);
        private const string DummyString = "DummyString";

        private const int DummyIntTwo = 2;
        private const int DummyMaxPeriod = 1;
        private const int PeriodId = 100;
        private const int CostTypeId = 110;
        private const int CostTypeUId = 111;
        private const int CustomFieldId = 11801;
        private const int CustomFieldId2 = 11811;
        private const int DummyUseFullName = 120;
        private const int DummyUseFullName2 = 121;
        private const int TargetId = 130;
        private const int TargetUId = 131;
        private const int DetailDataProjectId = 140;
        private const int DetailDataScenarioId = 141;
        private const int DetailDataScenarioId2 = 142;
        private const int DetailDataCtInd = 1;
        private const int DummyZCost = 150;
        private const int DummyZValue = 151;
        private const int DummyZFte = 152;
        private const int DummyTargetColoursId = 160;
        private const int DummyTargetColoursRgbVal = 161;
        private const int DummyCbId = 170;
        private const int DummyRateId = 180;
        private const int DetailRowScenarioId = 190;
        private const int DummyCatItemId = 200;
        private const int ListItemDataId = 210;
        private const int ListItemDataUid = 211;
        private const int ListItemDataLevel = 212;
        private const double DummyTargetColoursLowVal = 22;
        private const double DummyTargetColoursHighVal = 23;
        private const string DummyCostTypeName = "DummyCostTypeName";
        private const string DummyTargetName = "DummyTargetName";
        private const string DummyUseName = "DummyUseName";
        private const string DummyUseName2 = "DummyUseName2";
        private const string DummyExtraFieldName = "DummyExtraFieldName";
        private const string DummyExtraFieldName2 = "DummyExtraFieldName2";
        private const string DummyExtraFieldName3 = "DummyExtraFieldName3";
        private const string DummyCatItemName = "DummyCatItemName";
        private const string DummyCatItemFullName = "DummyCatItemFullName";
        private const string DummyMcVal = "DummyMcVal";
        private const string DummyRoleName = "DummyRoleName";
        private const string DummyUom = "DummyUom";
        private const string DummyItemDataName = "DummyItemDataName";
        private const string DummyItemDataFullName = "DummyItemDataFullName";
        private const string DummyFormat = "2";
        private const string DummyTargetId = "190";
        private const string ExpectedGetClientSideCalcDataResult = "<Result Context=\"GetTargetList\" Status=\"0\"><RatesAndCategories numberPeriods=\"1\"><Categories><Category ID=\"0\" UID=\"0\" Level=\"0\" Role_UID=\"0\" MC_UID=\"0\" Category=\"200\" Name=\"DummyCatItemName\" UoM=\"DummyUom\" FullName=\"DummyCatItemFullName\" MC_Val=\"DummyMcVal\" Role_Name=\"DummyRoleName\"><Rate Value=\"0\" /><Rate Value=\"0\" /><FTE Value=\"0\" /><FTE Value=\"0\" /></Category></Categories><CostTypes><CostType Id=\"111\" Name=\"DummyCostTypeName\" /></CostTypes><CustomFields><CustomField FieldID=\"11801\" Name=\"zDummyUseName\" LookupOnly=\"0\" LookupID=\"0\" LeafOnly=\"0\" UseFullName=\"120\" jsonMenu=\"{Items:[{Name:'210',Text:'DummyItemDataName',Value:'211'}]}\"><LookUps><LookUp ID=\"210\" UID=\"211\" Level=\"212\" Name=\"DummyItemDataName\" FullName=\"DummyItemDataFullName\" InActive=\"1\" /></LookUps></CustomField><CustomField FieldID=\"11811\" Name=\"zDummyUseName2\" LookupOnly=\"0\" LookupID=\"0\" LeafOnly=\"0\" UseFullName=\"121\" jsonMenu=\"\"><LookUps /></CustomField></CustomFields><NamedRates /><Periods><Period ID=\"100\" Name=\"\" /></Periods></RatesAndCategories></Result>";
        private const string ExpectedGetLegendKeyResult = "<Grid><Toolbar Visible=\"0\" /><Panel Visible=\"1\" Delete=\"0\" /><Cfg Code=\"GTACCNPSQEBSLC\" FilterEmpty=\"1\" SuppressMessage=\"3\" NoTreeLines=\"1\" MaxHeight=\"0\" ShowDeleted=\"0\" Deleting=\"0\" Selecting=\"0\" Dragging=\"0\" DragEdit=\"0\" MaxWidth=\"1\" HideHScroll=\"1\" SelectingCells=\"1\" DateStrings=\"1\" AppendId=\"0\" FullId=\"0\" IdChars=\"0123456789\" NumberId=\"1\" Style=\"GM\" CSS=\"ResPlanAnalyzer\" IdPrefix=\"R\" IdPostfix=\"x\" CaseSensitiveId=\"0\" /><LeftCols><C /><C Name=\"Key\" Type=\"Text\" Width=\"400\" CanEdit=\"0\" /></LeftCols><Header Visible=\"0\" Key=\" \" /><Body><B /><I Grouping=\"Totals\" CanEdit=\"0\"><I CanEdit=\"0\" NoColorState=\"1\" Key=\"\" KeyColor=\"RGB(161,0,0)\" /></I></Body></Grid>";
        private const string ExpectedGetTotalsConfigurationResult = "<Result Context=\"GetTotalsColumnsConfiguration\" Status=\"0\"><TotalsConfiguration><EnableHeatMap Value=\"0\" /><EnableHeatField Value=\"-1\" /><HeatFieldColour Value=\"1\" /><FIELD ID=\"1\" Name=\"Portfolio Items\" Selected=\"1\" /><FIELD ID=\"2\" Name=\"Cost Types\" Selected=\"0\" /><FIELD ID=\"4\" Name=\"Cost Categories\" Selected=\"1\" /><FIELD ID=\"11\" Name=\"Category\" Selected=\"0\" /><FIELD ID=\"8\" Name=\"Role\" Selected=\"0\" /><ColumnOptions><ColumnOption ColumnID=\"0\" Selected=\"1\" Name=\"Totals (from Top Grid)\" /><ColumnOption ColumnID=\"111\" Selected=\"0\" Name=\"DummyCostTypeName\" /><ColumnOption ColumnID=\"-131\" Selected=\"0\" Name=\"DummyTargetName\" /></ColumnOptions><SelectedOrderItems><Item ItemID=\"0\" /></SelectedOrderItems></TotalsConfiguration></Result>";
        private const string ExpectedCaLoadDataResult = "<Result Context=\"GetCostData\" Status=\"0\"><Perms Value=\"1\" /><Targets><MaxTargetID Value=\"-100\" /></Targets><Periods><CurrentPeriod Value=\"2\" /><Period perID=\"2\" perName=\"\" /></Periods><CostTypes><CostType ID=\"0\" Name=\"\" Sel=\"1\" Event=\"zCT0\" ButtonID=\"chkCT0\" /></CostTypes><DisplayMode><QTY Value=\"0\" /><FTE Value=\"0\" /><COST Value=\"1\" /><DECOST Value=\"1\" /><HideRowsWithAllZeros Value=\"1\" /></DisplayMode><Views /><TotalsConfiguration Value=\"&lt;TotalsConfiguration&gt;&lt;EnableHeatMap Value=&quot;0&quot; /&gt;&lt;EnableHeatField Value=&quot;-1&quot; /&gt;&lt;HeatFieldColour Value=&quot;1&quot; /&gt;&lt;FIELD ID=&quot;1&quot; Name=&quot;Portfolio Items&quot; Selected=&quot;1&quot; /&gt;&lt;FIELD ID=&quot;2&quot; Name=&quot;Cost Types&quot; Selected=&quot;0&quot; /&gt;&lt;FIELD ID=&quot;4&quot; Name=&quot;Cost Categories&quot; Selected=&quot;1&quot; /&gt;&lt;FIELD ID=&quot;11&quot; Name=&quot;Category&quot; Selected=&quot;0&quot; /&gt;&lt;FIELD ID=&quot;8&quot; Name=&quot;Role&quot; Selected=&quot;0&quot; /&gt;&lt;ColumnOptions&gt;&lt;ColumnOption ColumnID=&quot;0&quot; Selected=&quot;1&quot; Name=&quot;Totals (from Top Grid)&quot; /&gt;&lt;ColumnOption ColumnID=&quot;0&quot; Selected=&quot;0&quot; Name=&quot;&quot; /&gt;&lt;/ColumnOptions&gt;&lt;SelectedOrderItems&gt;&lt;Item ItemID=&quot;0&quot; /&gt;&lt;/SelectedOrderItems&gt;&lt;/TotalsConfiguration&gt;\" /><DisplayModeXML Value=\"&lt;DisplayMode&gt;&lt;QTY Value=&quot;0&quot; /&gt;&lt;FTE Value=&quot;0&quot; /&gt;&lt;COST Value=&quot;1&quot; /&gt;&lt;DECOST Value=&quot;1&quot; /&gt;&lt;HideRowsWithAllZeros Value=&quot;1&quot; /&gt;&lt;/DisplayMode&gt;\" /><PeriodRange Start=\"0\" Finish=\"1\" /></Result>";
        private const string ExpectedGetCostAnalyzerDataResult = "<Grid><Toolbar Visible=\"0\" /><Panel Visible=\"0\" Select=\"0\" Delete=\"0\" CanHide=\"0\" CanSelect=\"0\" /><Cfg MainCol=\"zXPortfolioItem\" Code=\"GTACCNPSQEBSLC\" SuppressCfg=\"3\" SuppressMessage=\"3\" Dragging=\"0\" Sorting=\"1\" ColsMoving=\"1\" ColsPosLap=\"1\" ColsLap=\"1\" VisibleLap=\"1\" SectionWidthLap=\"1\" GroupLap=\"1\" WideHScroll=\"0\" LeftWidth=\"150\" Width=\"400\" RightWidth=\"800\" MinMidWidth=\"50\" MinRightWidth=\"400\" LeftCanResize=\"0\" RightCanResize=\"1\" FocusWholeRow=\"1\" MaxHeight=\"0\" ShowDeleted=\"0\" DateStrings=\"1\" MaxWidth=\"1\" MaxSort=\"2\" AppendId=\"0\" FullId=\"0\" IdChars=\"0123456789\" NumberId=\"1\" LastId=\"1\" CaseSensitiveId=\"0\" Style=\"GM\" CSS=\"ResPlanAnalyzer\" FastColumns=\"1\" ExpandAllLevels=\"3\" GroupSortMain=\"1\" GroupRestoreSort=\"1\" NoTreeLines=\"1\" ShowVScroll=\"1\" /><LeftCols><C /><C Name=\"RowSel\" Type=\"Icon\" CanEdit=\"0\" CanMove=\"0\" CanResize=\"0\" CanExport=\"0\" CanFilter=\"0\" ShowHint=\"0\" CanSort=\"0\" Width=\"20\" Color=\"rgb(223, 227, 232)\" CanHide=\"0\" CanSelect=\"0\" /><C Name=\"rowid\" Type=\"Text\" CanExport=\"0\" ShowHint=\"0\" CanSort=\"0\" CanFilter=\"0\" CanResize=\"0\" Visible=\"0\" CanHide=\"0\" CanSelect=\"0\" /><C Name=\"Select\" Type=\"Bool\" CanEdit=\"1\" CanMove=\"0\" CanResize=\"0\" ShowHint=\"0\" CanSort=\"0\" CanFilter=\"0\" Width=\"20\" Class=\"\" CanHide=\"0\" CanSelect=\"0\" /></LeftCols><Cols><C Name=\"zXPortfolioItem\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" CanHide=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXStart\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXFinish\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXCostTypes\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXCostCategories\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXCategory\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXRole\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXMajorCategory\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXFullCostCategory\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXFullCategory\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXTotalCost\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXDisplayCost\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXDummyUseName\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXDummyUseName2\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXDummyExtraFieldName2\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXDummyExtraFieldName3\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /></Cols><RightCols><C Name=\"P100C1\" Type=\"Float\" ShowHint=\"0\" CanSort=\"0\" CanMove=\"0\" CanDrag=\"0\" CanHide=\"0\" CanSelect=\"0\" Align=\"Right\" MinWidth=\"45\" Width=\"65\" /></RightCols><Def><D Name=\"R\" Calculated=\"1\" HoverCell=\"Color\" HoverRow=\"Color\" FocusCell=\"\" NoColorState=\"1\" OnFocus=\"ClearSelection+Grid.SelectRow(Row,!Row.Selected)\" SelectCanEdit=\"1\" rowid=\"\" zXPortfolioItemCanDrag=\"0\" zXPortfolioItemHtmlPrefix=\"&lt;B&gt;\" zXPortfolioItemHtmlPostfix=\"&lt;/B&gt;\" xinterenalPeriodMinFormula=\"(Row.id == 'Filter' ? '' : min())\" xinterenalPeriodMinCanDrag=\"0\" xinterenalPeriodMaxFormula=\"(Row.id == 'Filter' ? '' : max())\" xinterenalPeriodMaxCanDrag=\"0\" zXStartCanDrag=\"0\" zXStartHtmlPrefix=\"&lt;B&gt;\" zXStartHtmlPostfix=\"&lt;/B&gt;\" zXFinishCanDrag=\"0\" zXFinishHtmlPrefix=\"&lt;B&gt;\" zXFinishHtmlPostfix=\"&lt;/B&gt;\" zXCostTypesCanDrag=\"0\" zXCostTypesHtmlPrefix=\"&lt;B&gt;\" zXCostTypesHtmlPostfix=\"&lt;/B&gt;\" zXCostCategoriesCanDrag=\"0\" zXCostCategoriesHtmlPrefix=\"&lt;B&gt;\" zXCostCategoriesHtmlPostfix=\"&lt;/B&gt;\" zXCategoryCanDrag=\"0\" zXCategoryHtmlPrefix=\"&lt;B&gt;\" zXCategoryHtmlPostfix=\"&lt;/B&gt;\" zXRoleCanDrag=\"0\" zXRoleHtmlPrefix=\"&lt;B&gt;\" zXRoleHtmlPostfix=\"&lt;/B&gt;\" zXMajorCategoryCanDrag=\"0\" zXMajorCategoryHtmlPrefix=\"&lt;B&gt;\" zXMajorCategoryHtmlPostfix=\"&lt;/B&gt;\" zXFullCostCategoryCanDrag=\"0\" zXFullCostCategoryHtmlPrefix=\"&lt;B&gt;\" zXFullCostCategoryHtmlPostfix=\"&lt;/B&gt;\" zXFullCategoryCanDrag=\"0\" zXFullCategoryHtmlPrefix=\"&lt;B&gt;\" zXFullCategoryHtmlPostfix=\"&lt;/B&gt;\" zXTotalCostCanDrag=\"0\" zXTotalCostHtmlPrefix=\"&lt;B&gt;\" zXTotalCostHtmlPostfix=\"&lt;/B&gt;\" zXDisplayCostCanDrag=\"0\" zXDisplayCostHtmlPrefix=\"&lt;B&gt;\" zXDisplayCostHtmlPostfix=\"&lt;/B&gt;\" zXDummyUseNameCanDrag=\"0\" zXDummyUseNameHtmlPrefix=\"&lt;B&gt;\" zXDummyUseNameHtmlPostfix=\"&lt;/B&gt;\" zXDummyUseName2CanDrag=\"0\" zXDummyUseName2HtmlPrefix=\"&lt;B&gt;\" zXDummyUseName2HtmlPostfix=\"&lt;/B&gt;\" zXDummyExtraFieldName2CanDrag=\"0\" zXDummyExtraFieldName2HtmlPrefix=\"&lt;B&gt;\" zXDummyExtraFieldName2HtmlPostfix=\"&lt;/B&gt;\" zXDummyExtraFieldName3CanDrag=\"0\" zXDummyExtraFieldName3HtmlPrefix=\"&lt;B&gt;\" zXDummyExtraFieldName3HtmlPostfix=\"&lt;/B&gt;\" P100C1Formula=\"(Row.id == 'Filter' ? '' : sum())\" P100C1Format=\",0.###\" P100C1CanDrag=\"0\" P100C1ClassInner=\"\" /><D Name=\"Leaf\" Calculated=\"0\" HoverCell=\"Color\" HoverRow=\"Color\" FocusCell=\"\" OnFocus=\"ClearSelection+Grid.SelectRow(Row,!Row.Selected)\" NoColorState=\"1\" zXPortfolioItemCanDrag=\"0\" zXPortfolioItemHtmlPrefix=\"\" zXPortfolioItemHtmlPostfix=\"\" xinterenalPeriodMinFormula=\"\" xinterenalPeriodMinCanDrag=\"0\" xinterenalPeriodMaxFormula=\"\" xinterenalPeriodMaxCanDrag=\"0\" zXStartCanDrag=\"0\" zXStartHtmlPrefix=\"\" zXStartHtmlPostfix=\"\" zXFinishCanDrag=\"0\" zXFinishHtmlPrefix=\"\" zXFinishHtmlPostfix=\"\" zXCostTypesCanDrag=\"0\" zXCostTypesHtmlPrefix=\"\" zXCostTypesHtmlPostfix=\"\" zXCostCategoriesCanDrag=\"0\" zXCostCategoriesHtmlPrefix=\"\" zXCostCategoriesHtmlPostfix=\"\" zXCategoryCanDrag=\"0\" zXCategoryHtmlPrefix=\"\" zXCategoryHtmlPostfix=\"\" zXRoleCanDrag=\"0\" zXRoleHtmlPrefix=\"\" zXRoleHtmlPostfix=\"\" zXMajorCategoryCanDrag=\"0\" zXMajorCategoryHtmlPrefix=\"\" zXMajorCategoryHtmlPostfix=\"\" zXFullCostCategoryCanDrag=\"0\" zXFullCostCategoryHtmlPrefix=\"\" zXFullCostCategoryHtmlPostfix=\"\" zXFullCategoryCanDrag=\"0\" zXFullCategoryHtmlPrefix=\"\" zXFullCategoryHtmlPostfix=\"\" zXTotalCostCanDrag=\"0\" zXTotalCostHtmlPrefix=\"\" zXTotalCostHtmlPostfix=\"\" zXDisplayCostCanDrag=\"0\" zXDisplayCostHtmlPrefix=\"\" zXDisplayCostHtmlPostfix=\"\" zXDummyUseNameCanDrag=\"0\" zXDummyUseNameHtmlPrefix=\"\" zXDummyUseNameHtmlPostfix=\"\" zXDummyUseName2CanDrag=\"0\" zXDummyUseName2HtmlPrefix=\"\" zXDummyUseName2HtmlPostfix=\"\" zXDummyExtraFieldName2CanDrag=\"0\" zXDummyExtraFieldName2HtmlPrefix=\"\" zXDummyExtraFieldName2HtmlPostfix=\"\" zXDummyExtraFieldName3CanDrag=\"0\" zXDummyExtraFieldName3HtmlPrefix=\"\" zXDummyExtraFieldName3HtmlPostfix=\"\" P100C1Formula=\"\" P100C1CanDrag=\"0\" P100C1ClassInner=\"\" /></Def><Head><Filter id=\"Filter\" /><Header PortfolioItemVisible=\"1\" Spanned=\"-1\" SortIcons=\"0\" HoverCell=\"Color\" HoverRow=\"\" RowSel=\" \" Select=\" \" zXPortfolioItem=\" \" zXStart=\" \" zXFinish=\" \" zXCostTypes=\" \" zXCostCategories=\" \" zXCategory=\" \" zXRole=\" \" zXMajorCategory=\" \" zXFullCostCategory=\" \" zXFullCategory=\" \" zXTotalCost=\" \" zXDisplayCost=\" \" zXDummyUseName=\" \" zXDummyUseName2=\" \" zXDummyExtraFieldName2=\" \" zXDummyExtraFieldName3=\" \" P100C1=\"Cost\" /></Head><Header PortfolioItemVisible=\"1\" Spanned=\"1\" SortIcons=\"2\" HoverCell=\"Color\" HoverRow=\"\" RowSel=\" \" Select=\" \" zXPortfolioItem=\"Portfolio Item\" zXStart=\"Start\" zXFinish=\"Finish\" zXCostTypes=\"Cost Types\" zXCostCategories=\"Cost Categories\" zXCategory=\"Category\" zXRole=\"Role\" zXMajorCategory=\"Major Category\" zXFullCostCategory=\"Full Cost Category\" zXFullCategory=\"Full Category\" zXTotalCost=\"Total Cost\" zXDisplayCost=\"Display Cost\" zXDummyUseName=\"DummyUseName\" zXDummyUseName2=\"DummyUseName2\" zXDummyExtraFieldName2=\"DummyExtraFieldName2\" zXDummyExtraFieldName3=\"DummyExtraFieldName3\" P100C1=\"\" /><Solid><Group /></Solid><Body><B /><I Grouping=\"Totals\" CanEdit=\"0\"><I id=\"1\" rowid=\"r1\" Color=\"white\" Def=\"Leaf\" NoColorState=\"1\" CanEdit=\"0\" Select=\"1\" SelectCanEdit=\"1\" zXPortfolioItem=\"\" zXCostTypes=\"\" zXCostCategories=\"\" zXCategory=\"\" zXRole=\"\" zXMajorCategory=\"\" zXFullCostCategory=\"\" zXFullCategory=\"\" zXTotalCost=\"0\" zXDisplayCost=\"0\" zXDummyUseName=\"\" zXDummyUseName2=\"\" zXDummyExtraFieldName2=\"2\" zXDummyExtraFieldName3=\"\" xinterenalPeriodMin=\"1\" xinterenalPeriodMax=\"0\" xinterenalPeriodTotal=\"1\" P1C1=\"150\" /></I></Body></Grid>";
        private const string ExpectedGetCostAnalyzerTotalsResult = "<Grid><Toolbar Visible=\"0\" /><Panel Visible=\"0\" Select=\"0\" Delete=\"0\" CanHide=\"0\" CanSelect=\"0\" /><Cfg MainCol=\"zXPortfolioItem\" Code=\"GTACCNPSQEBSLC\" SuppressCfg=\"3\" SuppressMessage=\"3\" Dragging=\"0\" Sorting=\"1\" ColsMoving=\"1\" ColsPosLap=\"1\" ColsLap=\"1\" VisibleLap=\"1\" SectionWidthLap=\"1\" GroupLap=\"1\" WideHScroll=\"0\" LeftWidth=\"150\" Width=\"400\" RightWidth=\"800\" MinMidWidth=\"50\" MinRightWidth=\"400\" LeftCanResize=\"0\" RightCanResize=\"1\" FocusWholeRow=\"1\" MaxHeight=\"0\" ShowDeleted=\"0\" DateStrings=\"1\" MaxWidth=\"1\" MaxSort=\"2\" AppendId=\"0\" FullId=\"0\" IdChars=\"0123456789\" NumberId=\"1\" LastId=\"1\" CaseSensitiveId=\"0\" Style=\"GM\" CSS=\"ResPlanAnalyzer\" FastColumns=\"1\" ExpandAllLevels=\"3\" GroupSortMain=\"1\" GroupRestoreSort=\"1\" NoTreeLines=\"1\" ShowVScroll=\"1\" /><LeftCols><C Name=\"rowid\" Type=\"Text\" CanExport=\"0\" ShowHint=\"0\" CanSort=\"0\" CanFilter=\"0\" CanResize=\"0\" Visible=\"0\" CanHide=\"0\" CanSelect=\"0\" /></LeftCols><Cols><C Name=\"zXPortfolioItem\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXCostTypes\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXCostCategories\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXCategory\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXRole\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXFullCategory\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Visible=\"0\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXTotalCost\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Visible=\"0\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXDisplayCost\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Visible=\"0\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXDummyUseName\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Visible=\"0\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXDummyUseName2\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Visible=\"0\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXDummyExtraFieldName2\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Visible=\"0\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"zXDummyExtraFieldName3\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Visible=\"0\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" /><C Name=\"xinterenalPeriodMin\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodMax\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /><C Name=\"xinterenalPeriodTotal\" ShowHint=\"0\" Type=\"Int\" CanSort=\"0\" CanMove=\"0\" Align=\"Right\" Visible=\"0\" CanSelect=\"0\" CanHide=\"0\" CanDrag=\"0\" /></Cols><RightCols><C Name=\"P100C1\" Type=\"Float\" ShowHint=\"0\" CanSort=\"0\" CanMove=\"0\" CanDrag=\"0\" CanHide=\"0\" CanSelect=\"0\" Align=\"Right\" MinWidth=\"45\" Width=\"65\" /></RightCols><Def><D Name=\"R\" Calculated=\"1\" HoverCell=\"Color\" HoverRow=\"Color\" FocusCell=\"\" NoColorState=\"1\" OnFocus=\"ClearSelection+Grid.SelectRow(Row,!Row.Selected)\" SelectCanEdit=\"1\" rowid=\"\" zXPortfolioItemCanDrag=\"0\" zXPortfolioItemHtmlPrefix=\"&lt;B&gt;\" zXPortfolioItemHtmlPostfix=\"&lt;/B&gt;\" xinterenalPeriodMinFormula=\"(Row.id == 'Filter' ? '' : min())\" xinterenalPeriodMinCanDrag=\"0\" xinterenalPeriodMaxFormula=\"(Row.id == 'Filter' ? '' : max())\" xinterenalPeriodMaxCanDrag=\"0\" zXCostTypesCanDrag=\"0\" zXCostTypesHtmlPrefix=\"&lt;B&gt;\" zXCostTypesHtmlPostfix=\"&lt;/B&gt;\" zXCostCategoriesCanDrag=\"0\" zXCostCategoriesHtmlPrefix=\"&lt;B&gt;\" zXCostCategoriesHtmlPostfix=\"&lt;/B&gt;\" zXCategoryCanDrag=\"0\" zXCategoryHtmlPrefix=\"&lt;B&gt;\" zXCategoryHtmlPostfix=\"&lt;/B&gt;\" zXRoleCanDrag=\"0\" zXRoleHtmlPrefix=\"&lt;B&gt;\" zXRoleHtmlPostfix=\"&lt;/B&gt;\" zXFullCategoryCanDrag=\"0\" zXFullCategoryHtmlPrefix=\"&lt;B&gt;\" zXFullCategoryHtmlPostfix=\"&lt;/B&gt;\" zXTotalCostCanDrag=\"0\" zXTotalCostHtmlPrefix=\"&lt;B&gt;\" zXTotalCostHtmlPostfix=\"&lt;/B&gt;\" zXDisplayCostCanDrag=\"0\" zXDisplayCostHtmlPrefix=\"&lt;B&gt;\" zXDisplayCostHtmlPostfix=\"&lt;/B&gt;\" zXDummyUseNameCanDrag=\"0\" zXDummyUseNameHtmlPrefix=\"&lt;B&gt;\" zXDummyUseNameHtmlPostfix=\"&lt;/B&gt;\" zXDummyUseName2CanDrag=\"0\" zXDummyUseName2HtmlPrefix=\"&lt;B&gt;\" zXDummyUseName2HtmlPostfix=\"&lt;/B&gt;\" zXDummyExtraFieldName2CanDrag=\"0\" zXDummyExtraFieldName2HtmlPrefix=\"&lt;B&gt;\" zXDummyExtraFieldName2HtmlPostfix=\"&lt;/B&gt;\" zXDummyExtraFieldName3CanDrag=\"0\" zXDummyExtraFieldName3HtmlPrefix=\"&lt;B&gt;\" zXDummyExtraFieldName3HtmlPostfix=\"&lt;/B&gt;\" X100C1Format=\"##\" X100C1Formula=\"(Row.id == 'Filter' ? '' : max())\" Y100C1Format=\"##\" Y100C1Formula=\"(Row.id == 'Filter' ? '' : min())\" P100C1Formula=\"(Row.id == 'Filter' ? '' : sum())\" P100C1Format=\",0.###\" P100C1CanDrag=\"0\" P100C1ClassInner=\"\" /><D Name=\"Leaf\" Calculated=\"0\" HoverCell=\"Color\" HoverRow=\"Color\" FocusCell=\"\" OnFocus=\"ClearSelection+Grid.SelectRow(Row,!Row.Selected)\" NoColorState=\"1\" zXPortfolioItemCanDrag=\"0\" zXPortfolioItemHtmlPrefix=\"\" zXPortfolioItemHtmlPostfix=\"\" xinterenalPeriodMinFormula=\"\" xinterenalPeriodMinCanDrag=\"0\" xinterenalPeriodMaxFormula=\"\" xinterenalPeriodMaxCanDrag=\"0\" zXCostTypesCanDrag=\"0\" zXCostTypesHtmlPrefix=\"\" zXCostTypesHtmlPostfix=\"\" zXCostCategoriesCanDrag=\"0\" zXCostCategoriesHtmlPrefix=\"\" zXCostCategoriesHtmlPostfix=\"\" zXCategoryCanDrag=\"0\" zXCategoryHtmlPrefix=\"\" zXCategoryHtmlPostfix=\"\" zXRoleCanDrag=\"0\" zXRoleHtmlPrefix=\"\" zXRoleHtmlPostfix=\"\" zXFullCategoryCanDrag=\"0\" zXFullCategoryHtmlPrefix=\"\" zXFullCategoryHtmlPostfix=\"\" zXTotalCostCanDrag=\"0\" zXTotalCostHtmlPrefix=\"\" zXTotalCostHtmlPostfix=\"\" zXDisplayCostCanDrag=\"0\" zXDisplayCostHtmlPrefix=\"\" zXDisplayCostHtmlPostfix=\"\" zXDummyUseNameCanDrag=\"0\" zXDummyUseNameHtmlPrefix=\"\" zXDummyUseNameHtmlPostfix=\"\" zXDummyUseName2CanDrag=\"0\" zXDummyUseName2HtmlPrefix=\"\" zXDummyUseName2HtmlPostfix=\"\" zXDummyExtraFieldName2CanDrag=\"0\" zXDummyExtraFieldName2HtmlPrefix=\"\" zXDummyExtraFieldName2HtmlPostfix=\"\" zXDummyExtraFieldName3CanDrag=\"0\" zXDummyExtraFieldName3HtmlPrefix=\"\" zXDummyExtraFieldName3HtmlPostfix=\"\" P100C1Formula=\"\" P100C1CanDrag=\"0\" P100C1ClassInner=\"\" X100C1Formula=\"\" Y100C1Formula=\"\" /></Def><Head><Filter id=\"Filter\" /><Header PortfolioItemVisible=\"1\" Spanned=\"-1\" SortIcons=\"0\" HoverCell=\"Color\" HoverRow=\"\" zXPortfolioItem=\" \" zXCostTypes=\" \" zXCostCategories=\" \" zXCategory=\" \" zXRole=\" \" zXFullCategory=\" \" zXTotalCost=\" \" zXDisplayCost=\" \" zXDummyUseName=\" \" zXDummyUseName2=\" \" zXDummyExtraFieldName2=\" \" zXDummyExtraFieldName3=\" \" P100C1=\"Totals\" /></Head><Header PortfolioItemVisible=\"1\" Spanned=\"1\" SortIcons=\"2\" HoverCell=\"Color\" HoverRow=\"\" zXPortfolioItem=\"Portfolio Item\" zXCostTypes=\"Cost Types\" zXCostCategories=\"Cost Categories\" zXCategory=\"Category\" zXRole=\"Role\" zXFullCategory=\"Full Category\" zXTotalCost=\"Total Cost\" zXDisplayCost=\"Display Cost\" zXDummyUseName=\"DummyUseName\" zXDummyUseName2=\"DummyUseName2\" zXDummyExtraFieldName2=\"DummyExtraFieldName2\" zXDummyExtraFieldName3=\"DummyExtraFieldName3\" P100C1=\"\" /><Solid><Group /></Solid><Body><B /><I Grouping=\"Totals\" CanEdit=\"0\"><I id=\"1\" Color=\"white\" Def=\"Leaf\" NoColorState=\"1\" CanEdit=\"0\" zXPortfolioItem=\"\" zXCostTypes=\"\" zXCostCategories=\"\" zXCategory=\"\" zXRole=\"\" zXFullCategory=\"\" zXTotalCost=\"0\" zXDisplayCost=\"0\" zXDummyUseName=\"\" zXDummyUseName2=\"\" zXDummyExtraFieldName2=\"\" zXDummyExtraFieldName3=\"\" xinterenalPeriodMin=\"1\" xinterenalPeriodMax=\"0\" xinterenalPeriodTotal=\"1\" P1C1=\"150\" /></I></Body></Grid>";
        private const string ExpectedGetTargetGridResult = "<Grid><Toolbar Visible=\"0\" /><Panel Visible=\"0\" Select=\"0\" Delete=\"0\" CanHide=\"0\" CanSelect=\"0\" /><Cfg MainCol=\"CostCategory\" ShowDeleted=\"0\" Deleting=\"0\" Selecting=\"0\" ColResizing=\"1\" ExpandAllLevels=\"3\" DateStrings=\"1\" NoTreeLines=\"1\" MaxWidth=\"1\" AppendId=\"0\" FullId=\"0\" IdChars=\"0123456789\" NumberId=\"1\" FilterEmpty=\"1\" Dragging=\"0\" DragEdit=\"0\" ExportFormat=\"1\" IdPrefix=\"R\" IdPostfix=\"x\" CaseSensitiveId=\"0\" Code=\"GTACCNPSQEBSLC\" Style=\"GM\" CSS=\"ResPlanAnalyzer\" LeftWidth=\"400\" GroupSortMain=\"1\" GroupRestoreSort=\"1\" SuppressCfg=\"1\" PrintCols=\"0\" Sorting=\"0\" /><LeftCols><C Name=\"Select\" Type=\"Bool\" CanEdit=\"1\" CanMove=\"0\" Width=\"20\" /><C Name=\"rowid\" CanEdit=\"0\" Visible=\"0\" /><C Type=\"Text\" Name=\"CostType\" Visible=\"0\" CanEdit=\"0\" Defaults=\"\" /><C Name=\"CostCategory\" Type=\"Text\" CanEdit=\"0\" Defaults=\"\" /><C Name=\"MajorCategory\" CanEdit=\"0\" Visible=\"0\" /><C Name=\"Role\" CanEdit=\"0\" /><C Name=\"NamedRate\" CanEdit=\"0\" /><C Name=\"zDummyUseName\" CanEdit=\"0\" Defaults=\"\" /><C Name=\"zDummyUseName2\" CanEdit=\"0\" Defaults=\"\" /></LeftCols><Cols><C Name=\"P1V\" Type=\"Float\" CanMove=\"0\" Format=\"0.###\" /><C Name=\"P1C\" Type=\"Float\" CanMove=\"0\" Format=\"#.##\" /></Cols><Def><D Name=\"R\" Calculated=\"1\" HoverCell=\"Color\" HoverRow=\"Color\" FocusCell=\"\" NoColorState=\"1\" OnFocus=\"ClearSelection+Grid.SelectRow(Row,!Row.Selected)\" SelectCanEdit=\"0\" rowid=\"\" CostTypeHtmlPrefix=\"&lt;B&gt;\" CostTypeHtmlPostfix=\"&lt;/B&gt;\" CostCategoryHtmlPrefix=\"&lt;B&gt;\" CostCategoryHtmlPostfix=\"&lt;/B&gt;\" MajorCategoryHtmlPrefix=\"&lt;B&gt;\" MajorCategoryHtmlPostfix=\"&lt;/B&gt;\" RoleHtmlPrefix=\"&lt;B&gt;\" RoleHtmlPostfix=\"&lt;/B&gt;\" NamedRateHtmlPrefix=\"&lt;B&gt;\" NamedRateHtmlPostfix=\"&lt;/B&gt;\" zDummyUseNameHtmlPrefix=\"&lt;B&gt;\" zDummyUseNameHtmlPostfix=\"&lt;/B&gt;\" zDummyUseName2HtmlPrefix=\"&lt;B&gt;\" zDummyUseName2HtmlPostfix=\"&lt;/B&gt;\" P1VFormula=\"(Row.id == 'Filter' ? '' : sum())\" P1VFormat=\"0.###\" P1VCanEdit=\"0\" P1CFormula=\"(Row.id == 'Filter' ? '' : sum())\" P1CFormat=\"#.##\" P1CCanEdit=\"0\" /><D Name=\"Leaf\" Calculated=\"0\" HoverCell=\"Color\" HoverRow=\"Color\" FocusCell=\"\" OnFocus=\"ClearSelection+Grid.SelectRow(Row,!Row.Selected)\" NoColorState=\"1\" SelectCanEdit=\"1\" CostTypeHtmlPrefix=\"\" CostTypeHtmlPostfix=\"\" CostTypeCanEdit=\"0\" CostCategoryHtmlPrefix=\"\" CostCategoryHtmlPostfix=\"\" CostCategoryCanEdit=\"0\" MajorCategoryHtmlPrefix=\"\" MajorCategoryHtmlPostfix=\"\" MajorCategoryCanEdit=\"0\" RoleHtmlPrefix=\"\" RoleHtmlPostfix=\"\" RoleCanEdit=\"0\" NamedRateHtmlPrefix=\"\" NamedRateHtmlPostfix=\"\" NamedRateCanEdit=\"0\" zDummyUseNameHtmlPrefix=\"\" zDummyUseNameHtmlPostfix=\"\" zDummyUseNameCanEdit=\"0\" zDummyUseName2HtmlPrefix=\"\" zDummyUseName2HtmlPostfix=\"\" zDummyUseName2CanEdit=\"0\" P1VFormula=\"\" P1CFormula=\"\" /></Def><Head><Header Spanned=\"-1\" SortIcons=\"0\" Select=\" \" rowid=\" \" CostType=\"Cost\" CostCategory=\"Cost\" MajorCategory=\"Major\" Role=\" \" NamedRate=\"Named \" zDummyUseName=\" \" zDummyUseName2=\" \" P1VSpan=\"2\" P1V=\"\" /><Header id=\"Header\" SortIcons=\"0\" Select=\" \" rowid=\" \" CostType=\"Type\" CostCategory=\"Category\" MajorCategory=\"Category\" Role=\"Role\" NamedRate=\"Rate\" zDummyUseName=\"\" zDummyUseName2=\"\" P1V=\" Qty \" P1C=\" Cost \" /></Head><Solid><Group /></Solid><Body><B /><I Grouping=\"Totals\" CanEdit=\"0\" /></Body></Grid>";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testObject = new CostAnalyzer();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
            _testObject?.Dispose();
        }

        [TestMethod]
        public void Execute_ThrowsException_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;

            // Act
            var actualResult = _testObject.Execute("CALoadData", DummyString);

            // Assert
            actualResult.ShouldBe("<Result Context=\"Execute\" Status=\"99999\"><Error ID=\"100\" Value=\"Error executing function: Exception has been thrown by the target of an invocation.\" /></Result>");
        }

        [TestMethod]
        public void Execute_AuthenticateUserAndProductFalse_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return false;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext()
            {
                SessionGet = () => new ShimHttpSessionState()
                {
                    ItemGetString = keyString => new CostAnalyzerDataCache()
                }
            };

            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;

            // Act
            var actualResult = _testObject.Execute("GetPortfolioItemList", DummyString);

            // Assert
            actualResult.ShouldBe("<Result Context=\"Execute\" Status=\"99999\"><Error ID=\"100\" Value=\"PfE User Authentication Failed. Stage: DummyString\" /></Result>");
        }

        [TestMethod]
        public void Execute_OnValidCall_ReturnsStringSetSessionValue()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };

            var sessionObject = new object();
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext()
            {
                SessionGet = () => new ShimHttpSessionState()
                {
                    ItemSetStringObject = (stringKey, valueParam) => sessionObject = valueParam
                }
            };

            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;

            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };

            // Act
            var actualResult = _testObject.Execute("CALoadData", XmlDummy());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => sessionObject.ShouldBeOfType<CostAnalyzerDataCache>(),
                () => actualResult.ShouldBe("<Result Context=\"CostAnalyzer.CALoadData at 30\" Status=\"99999\"><Error ID=\"100\" Value=\"\" /></Result>"));
        }

        [TestMethod]
        public void ExecuteJson_ThrowsException_ReturnsJsonString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;

            // Act
            var actualResult = _testObject.ExecuteJSON("GetPortfolioItemList", DummyString);

            // Assert
            actualResult.ShouldBe("{ \"Result\": {\"Context\": \"ExecuteJSON\", \"Error\": {\"ID\": \"100\", \"Value\": \"Error executing function: Object reference not set to an instance of an object.\" }, \"Status\": \"99999\" }}");
        }

        [TestMethod]
        public void ExecuteJson_OnValidCall_ReturnsJsonStringSetSessionValue()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };

            var sessionObject = new object();
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext()
            {
                SessionGet = () => new ShimHttpSessionState()
                {
                    ItemSetStringObject = (stringKey, valueParam) => sessionObject = valueParam
                }
            };

            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;

            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };

            // Act
            var actualResult = _testObject.ExecuteJSON("CALoadData", XmlDummy());

            // Assert
            this.ShouldSatisfyAllConditions(
                () => sessionObject.ShouldBeOfType<CostAnalyzerDataCache>(),
                () => actualResult.ShouldBe("{ \"Result\": {\"Context\": \"CostAnalyzer.CALoadData at 30\", \"Error\": {\"ID\": \"100\", \"Value\": \"\" }, \"Status\": \"99999\" }}"));
        }

        [TestMethod]
        public void GetPortfolioItemList_OnValidCall_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = sender => true;

            var context = new ShimHttpContext();

            var dataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.GetPortfolioItemList(context, string.Empty, dataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"GetPortfolioItemList\" Status=\"0\"><IDLists EXTLIST=\"\" IDLIST=\"\" /></Result>");
        }

        [TestMethod]
        public void GetPortfolioItemList_ThrowsException_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = sender => true;

            ShimPortfolioItems.AllInstances.ObtainManagedPortfolioItemsStringOutStringOutStringOut =
                (PortfolioItems sender, out string extIdList, out string pidList, out string xml) =>
                {
                    extIdList = string.Empty;
                    pidList = string.Empty;
                    xml = string.Empty;
                    throw new Exception();
                };

            var context = new ShimHttpContext();

            var dataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.GetPortfolioItemList(context, string.Empty, dataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"GetPortfolioItemList\" Status=\"99999\"><Error ID=\"100\" Value=\"Exception in CostAnalyzer.asmx (): 'Exception of type 'System.Exception' was thrown.'\" /></Result>");
        }

        [TestMethod]
        public void GetGeneratedPortfolioItemTicket_OnValidCall_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = sender => true;

            var context = new ShimHttpContext();

            var dataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.GetGeneratedPortfolioItemTicket(context, string.Empty, dataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"GetGeneratedPortfolioItemTicket\" Status=\"0\"><Ticket Value=\"\" /></Result>");
        }

        [TestMethod]
        public void GetGeneratedPortfolioItemTicket_ThrowsException_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = sender => true;

            ShimPortfolioItems.AllInstances.GeneratePortfolioItemTicketString =
                (PortfolioItems sender, string xml) =>
                {
                    throw new Exception();
                };

            var context = new ShimHttpContext();

            var dataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.GetGeneratedPortfolioItemTicket(context, string.Empty, dataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"GetGeneratedPortfolioItemTicket\" Status=\"99999\"><Error ID=\"100\" Value=\"Exception in CostAnalyzer.asmx (): 'Exception of type 'System.Exception' was thrown.'\" /></Result>");
        }

        [TestMethod]
        public void CASessionPing_OnValidCall_ReturnsStringEmpty()
        {
            // Arrange, Act
            var actualResult = CostAnalyzer.CASessionPing(new ShimHttpContext(), string.Empty, new CostAnalyzerDataCache());

            // Assert
            actualResult.ShouldBeEmpty();
        }

        [TestMethod]
        public void CALoadData_GPoPerm0_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = sender => true;
            ShimCostAnalyzerData.AllInstances.InitalLoadDataStringStringStringOutInt32Out =
                (CostAnalyzerData sender, string ticket, string viewId, out string loadMsg, out int loadDataReturn) =>
                {
                    loadMsg = string.Empty;
                    loadDataReturn = 0;
                    return new clsCostData();
                };

            // Act
            var actualResult = CostAnalyzer.CALoadData(new ShimHttpContext(), XmlCaLoadData(), new CostAnalyzerDataCache());

            // Assert
            actualResult.ShouldBe("<Result Context=\"GetCostData\" Status=\"0\"><Perms Value=\"0\" /></Result>");
        }

        [TestMethod]
        public void CALoadData_GPoPermNot0_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };
            ShimSqlCommand.AllInstances.ExecuteScalar = sender => true;
            ShimCostAnalyzerData.AllInstances.InitalLoadDataStringStringStringOutInt32Out =
                (CostAnalyzerData sender, string ticket, string viewId, out string loadMsg, out int loadDataReturn) =>
                {
                    loadMsg = string.Empty;
                    loadDataReturn = 0;
                    return new clsCostData()
                    {
                        m_gPOPerm = 1,
                        m_Periods = new Dictionary<int, clsPeriodData>()
                        {
                            {
                                1,
                                new clsPeriodData()
                                {
                                    StartDate = DummyDateTime,
                                    FinishDate = DummyDateTime,
                                    PeriodID = 2
                                }
                            }
                        },
                        m_CostTypes = new Dictionary<int, clsDataItem>()
                        {
                            {
                                1,
                                new clsDataItem()
                            }
                        },
                        m_CustFields = new Dictionary<int, clsCustomFieldData>(),
                        m_targets = new Dictionary<int, clsDataItem>(),
                        m_PIs = new Dictionary<string, clsPIData>(),
                        m_detaildata = new Dictionary<string, clsDetailRowData>(),
                        m_targetdata = new Dictionary<string, clsDetailRowData>(),
                        m_clsTargetColours = new List<clsTargetColours>()
                    };
                };

            // Act
            var actualResult = CostAnalyzer.CALoadData(new ShimHttpContext(), XmlCaLoadData(), new CostAnalyzerDataCache());

            // Assert
            actualResult.ShouldBe(ExpectedCaLoadDataResult);
        }

        [TestMethod]
        public void SetCTDetails_LoadXmlFalse_ReturnsString()
        {
            // Arrange, Act
            var actualResult = CostAnalyzer.SetCTDetails(new ShimHttpContext(), string.Empty, new CostAnalyzerDataCache());

            // Assert
            actualResult.ShouldBe("<Result Context=\"SetCTDetails\" Status=\"99999\"><Error ID=\"100\" Value=\"Invalid request xml\" /></Result>");
        }

        [TestMethod]
        public void SetCTDetails_OnValidCall_ReturnsStringEmpty()
        {
            // Arrange
            var actualSetCtDetailsCalled = false;

            ShimCostAnalyzerDataCache.AllInstances.SetCTStateDataCStruct = (sender, cStruct) => actualSetCtDetailsCalled = true;

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.SetCTDetails(new ShimHttpContext(), XmlDummy(), costAnalyzerDataCache);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeEmpty(),
                () => actualSetCtDetailsCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void SetDisplayMode_LoadXmlFalse_ReturnsString()
        {
            // Arrange, Act
            var actualResult = CostAnalyzer.SetDisplayMode(new ShimHttpContext(), string.Empty, new CostAnalyzerDataCache());

            // Assert
            actualResult.ShouldBe("<Result Context=\"SetDisplayMode\" Status=\"99999\"><Error ID=\"100\" Value=\"Invalid request xml\" /></Result>");
        }

        [TestMethod]
        public void SetDisplayMode_OnValidCall_ReturnsStringEmpty()
        {
            // Arrange
            var actualSetDisplayModeCalled = false;

            ShimCostAnalyzerDataCache.AllInstances.SetDisplayModeCStruct = (sender, cStruct) => actualSetDisplayModeCalled = true;

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.SetDisplayMode(new ShimHttpContext(), XmlDummy(), costAnalyzerDataCache);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeEmpty(),
                () => actualSetDisplayModeCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void GetCostAnalyzerData_OnValidCall_ReturnsString()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.GetCostAnalyzerData(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe(ExpectedGetCostAnalyzerDataResult);
        }

        [TestMethod]
        public void GetCostAnalyzerTotals_OnValidCall_ReturnsString()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.GetCostAnalyzerTotals(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe(ExpectedGetCostAnalyzerTotalsResult);
        }

        [TestMethod]
        public void GetTargetGrid_OnValidCall_ReturnsString()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.GetTargetGrid(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe(ExpectedGetTargetGridResult);
        }

        [TestMethod]
        public void GetTotalsConfiguration_OnValidCall_ReturnsString()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.GetTotalsConfiguration(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe(ExpectedGetTotalsConfigurationResult);
        }

        [TestMethod]
        public void SetTotalsConfiguration_LoadXmlFalse_ReturnsString()
        {
            // Arrange, Act
            var actualResult = CostAnalyzer.SetTotalsConfiguration(new ShimHttpContext(), string.Empty, new CostAnalyzerDataCache());

            // Assert
            actualResult.ShouldBe("<Result Context=\"SetColumnsConfiguration\" Status=\"99999\"><Error ID=\"100\" Value=\"Invalid request xml\" /></Result>");
        }

        [TestMethod]
        public void SetTotalsConfiguration_OnValidCall_ReturnsStringEmpty()
        {
            // Arrange
            var actualSetTotalsDataCalled = false;

            ShimCostAnalyzerDataCache.AllInstances.SetTotalsDataCStruct = (sender, cStruct) => actualSetTotalsDataCalled = true;

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.SetTotalsConfiguration(new ShimHttpContext(), XmlDummy(), costAnalyzerDataCache);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeEmpty(),
                () => actualSetTotalsDataCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void GetCompareCostTypeList_OnValidCall_ReturnsString()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.GetCompareCostTypeList(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"GetCompareCostTypeList\" Status=\"0\"><CTCmpConfiguration><CostType ID=\"111\" Name=\"DummyCostTypeName\" Selected=\"0\" /></CTCmpConfiguration></Result>");
        }

        [TestMethod]
        public void SetCompareCostTypeList_LoadXmlFalse_ReturnsString()
        {
            // Arrange, Act
            var actualResult = CostAnalyzer.SetCompareCostTypeList(new ShimHttpContext(), string.Empty, new CostAnalyzerDataCache());

            // Assert
            actualResult.ShouldBe("<Result Context=\"SetCompareCostTypeList\" Status=\"99999\"><Error ID=\"100\" Value=\"Invalid request xml\" /></Result>");
        }

        [TestMethod]
        public void SetCompareCostTypeList_OnValidCall_ReturnsStringEmpty()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.SetCompareCostTypeList(new ShimHttpContext(), XmlDummy(), costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"SetCompareCostTypeList\" Status=\"0\"><HeatMapText Value=\"\" /></Result>");
        }

        [TestMethod]
        public void SetDetailsSelectedFlag_LoadXmlFalse_ReturnsString()
        {
            // Arrange, Act
            var actualResult = CostAnalyzer.SetDetailsSelectedFlag(new ShimHttpContext(), string.Empty, new CostAnalyzerDataCache());

            // Assert
            actualResult.ShouldBe("<Result Context=\"SetDetailsSelectedFlag\" Status=\"99999\"><Error ID=\"100\" Value=\"Invalid request xml\" /></Result>");
        }

        [TestMethod]
        public void SetDetailsSelectedFlag_OnValidCall_ReturnsStringEmpty()
        {
            // Arrange
            var actualSetSelectedForRowsCalled = false;

            ShimCostAnalyzerDataCache.AllInstances.SetSelectedForRowsCStruct = (sender, cStruct) => actualSetSelectedForRowsCalled = true;

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.SetDetailsSelectedFlag(new ShimHttpContext(), XmlDummy(), costAnalyzerDataCache);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeEmpty(),
                () => actualSetSelectedForRowsCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void SetDetailsFilteredFlag_LoadXmlFalse_ReturnsString()
        {
            // Arrange, Act
            var actualResult = CostAnalyzer.SetDetailsFilteredFlag(new ShimHttpContext(), string.Empty, new CostAnalyzerDataCache());

            // Assert
            actualResult.ShouldBe("<Result Context=\"SetDetailsFilteredFlag\" Status=\"99999\"><Error ID=\"100\" Value=\"Invalid request xml\" /></Result>");
        }

        [TestMethod]
        public void SetDetailsFilteredFlag_OnValidCall_ReturnsStringEmpty()
        {
            // Arrange
            var actualSetFilteredForRowsCalled = false;

            ShimCostAnalyzerDataCache.AllInstances.SetFilteredForRowsCStruct = (sender, cStruct) => actualSetFilteredForRowsCalled = true;

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.SetDetailsFilteredFlag(new ShimHttpContext(), XmlDummy(), costAnalyzerDataCache);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeEmpty(),
                () => actualSetFilteredForRowsCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void GetLegendKey_OnValidCall_ReturnsString()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.GetLegendKey(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe(ExpectedGetLegendKeyResult);
        }

        [TestMethod]
        public void SetShowRemaining_OnValidCall_ReturnsStringEmpty()
        {
            // Arrange
            var actualSetFilteredForRowsCalled = false;

            ShimCostAnalyzerDataCache.AllInstances.SetShowRemainingBoolean = (sender, boolParam) => actualSetFilteredForRowsCalled = boolParam;

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.SetShowRemaining(new ShimHttpContext(), "1", costAnalyzerDataCache);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldBeEmpty(),
                () => actualSetFilteredForRowsCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void SaveCostPlanAnalyzerView_LoadXmlFalse_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.SaveCostPlanAnalyzerView(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"SaveCostPlanAnalyzerView\" Status=\"99999\"><Error ID=\"100\" Value=\"Invalid request xml\" /></Result>");
        }

        [TestMethod]
        public void SaveCostPlanAnalyzerView_ThrowsException_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.SaveCostPlanAnalyzerView(new ShimHttpContext(), XmlCaLoadData(), costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"SaveCostAnalyzerView\" Status=\"99999\"><Error ID=\"100\" Value=\"Exception in CostAnalyzer.asmx (): 'Object reference not set to an instance of an object.'\" /></Result>");
        }

        [TestMethod]
        public void SaveCostPlanAnalyzerView_OnValidCall_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = sender => 1;

            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.SaveCostPlanAnalyzerView(new ShimHttpContext(), XmlView(), costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"SaveCostAnalyzerView\" Status=\"0\"><View ViewGUID=\"be161112-c79c-4289-b3b3-7334cd51a373\" Name=\"DummyName\" Personal=\"1\" Default=\"1\" /></Result>");
        }

        [TestMethod]
        public void DeleteCostAnalyzerView_LoadXmlFalse_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.DeleteCostAnalyzerView(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"DeleteResourceAnalyzerView\" Status=\"99999\"><Error ID=\"100\" Value=\"Invalid request xml\" /></Result>");
        }

        [TestMethod]
        public void DeleteCostAnalyzerView_ThrowsException_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.DeleteCostAnalyzerView(new ShimHttpContext(), XmlCaLoadData(), costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"DeleteResourceAnalyzerView\" Status=\"99999\"><Error ID=\"100\" Value=\"Exception in CostAnalyzer.asmx (): 'Object reference not set to an instance of an object.'\" /></Result>");
        }

        [TestMethod]
        public void DeleteCostAnalyzerView_OnValidCall_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = sender => 1;

            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.DeleteCostAnalyzerView(new ShimHttpContext(), XmlView(), costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"DeleteResourceAnalyzerView\" Status=\"0\"><View ViewGUID=\"be161112-c79c-4289-b3b3-7334cd51a373\" Name=\"DummyName\" Personal=\"1\" Default=\"1\" /></Result>");
        }

        [TestMethod]
        public void RenameCostAnalyzerView_LoadXmlFalse_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.RenameCostAnalyzerView(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"RenameResourceAnalyzerView\" Status=\"99999\"><Error ID=\"100\" Value=\"Invalid request xml\" /></Result>");
        }

        [TestMethod]
        public void RenameCostAnalyzerView_ThrowsException_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };

            var costAnalyzerDataCache = new CostAnalyzerDataCache();

            // Act
            var actualResult = CostAnalyzer.RenameCostAnalyzerView(new ShimHttpContext(), XmlCaLoadData(), costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"RenameResourceAnalyzerView\" Status=\"99999\"><Error ID=\"100\" Value=\"Exception in CostAnalyzer.asmx (): 'Object reference not set to an instance of an object.'\" /></Result>");
        }

        [TestMethod]
        public void RenameCostAnalyzerView_OnValidCall_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            System.Web.Services.Fakes.ShimWebService.AllInstances.ContextGet = sender => new ShimHttpContext();
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;
            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = sender => 1;
            ShimCostAnalyzerData.AllInstances.RenameCostAnalyzerViewXMLGuidString = (sender, guid, name) => true;

            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.RenameCostAnalyzerView(new ShimHttpContext(), XmlView(), costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"RenameResourceAnalyzerView\" Status=\"0\"><View ViewGUID=\"be161112-c79c-4289-b3b3-7334cd51a373\" Name=\"DummyName\" Personal=\"1\" Default=\"1\" /></Result>");
        }

        [TestMethod]
        public void ApplyCostAnalyzerViewServerSideSettings_OnValidCall_ReturnsString()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.ApplyCostAnalyzerViewServerSideSettings(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"ApplyCostAnalyzerViewServerSideSettings\" Status=\"0\" />");
        }

        [TestMethod]
        public void GetTargetList_OnValidCall_ReturnsString()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.GetTargetList(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"GetTargetList\" Status=\"0\"><Targets><Target Name=\"DummyTargetName\" ID=\"131\" /></Targets></Result>");
        }

        [TestMethod]
        public void DeleteTarget_OnValidCall_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;

            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };

            ShimCostAnalyzerDataCache.AllInstances.DeleteTargetInt32StringOut = (CostAnalyzerDataCache sender, int delTarget, out string heatMapText) =>
            {
                heatMapText = DummyString;
                return true;
            };

            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.DeleteTarget(new ShimHttpContext(), DummyTargetId, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"DeleteTarget\" Status=\"0\"><HeatMapText Value=\"DummyString\" /></Result>");
        }

        [TestMethod]
        public void GetClientSideCalcData_OnValidCall_ReturnsString()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.GetClientSideCalcData(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe(ExpectedGetClientSideCalcDataResult);
        }

        [TestMethod]
        public void GetTargetTotalsData_OnValidCall_ReturnsString()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.GetTargetTotalsData(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"GetTargetTotalsData\" Status=\"0\"><TargetTotalData /></Result>");
        }

        [TestMethod]
        public void PrepareTargetData_OnValidCall_ReturnsString()
        {
            // Arrange
            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.PrepareTargetData(new ShimHttpContext(), string.Empty, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"GetTargetData\" Status=\"0\" />");
        }

        [TestMethod]
        public void SaveTargetData_OnValidCall_ReturnsString()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    SiteGet = () => new ShimSPSite()
                    {
                        IDGet = () => DummySiteGuid
                    }
                }
            };
            ShimSPSite.ConstructorGuid = (sender, guid) => new ShimSPSite(sender)
            {
                RootWebGet = () => new ShimSPWeb()
            };
            ShimWebAdmin.AuthenticateUserAndProductHttpContextStringOut = (HttpContext context, out string stage) =>
            {
                stage = DummyString;
                return true;
            };
            ShimConfigFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimCoreFunctions.getConfigSettingSPWebString = (web, setting) => setting;
            ShimConfigFunctions.GetCleanUsernameSPWeb = web => DummyString;

            ShimSqlConnection.AllInstances.Open = sender => { };
            ShimSqlConnection.AllInstances.Close = sender => { };
            ShimSqlCommand.AllInstances.ExecuteReader = sender => new ShimSqlDataReader()
            {
                Read = () => false,
                Close = () => { }
            };

            ShimCostAnalyzerData.AllInstances.SaveTargetDataStringInt32Int32OutStringOutBooleanOut = (
                CostAnalyzerData sender,
                string xml,
                int cbId,
                out int targetId,
                out string sTargetName,
                out bool bNewTarget) =>
            {
                targetId = TargetId;
                sTargetName = DummyTargetName;
                bNewTarget = true;
            };

            var costAnalyzerDataCache = new CostAnalyzerDataCache();
            costAnalyzerDataCache.GrabCAData(CreateCostData());

            // Act
            var actualResult = CostAnalyzer.SaveTargetData(new ShimHttpContext(), DummyTargetId, costAnalyzerDataCache);

            // Assert
            actualResult.ShouldBe("<Result Context=\"SaveTarget\" Status=\"0\"><SaveTarget><Target Value=\"130\" /></SaveTarget></Result>");
        }

        private static string XmlDummy()
        {
            return @"
<Node >
</Node>";
        }

        private static string XmlCaLoadData()
        {
            return @"
<Node Ticket='DummyTicket' ViewID='DummyViewId'>
</Node>";
        }

        private static string XmlView()
        {
            return @"
<Node>
    <View ViewGUID='be161112-c79c-4289-b3b3-7334cd51a373' Name='DummyName' Personal='1' Default='1'/>
</Node>";
        }

        private static clsCostData CreateCostData()
        {
            var extraFieldTypes = new int[257];
            extraFieldTypes[1] = DummyIntTwo;

            var piExtraData = new string[257];
            piExtraData[1] = DummyFormat;
            var piFormatExtraData = new string[257];

            var pisName = $"{DetailDataProjectId} {DetailDataScenarioId}";

            return new clsCostData()
            {
                m_Periods = new Dictionary<int, clsPeriodData>()
                {
                    {
                        PeriodId,
                        new clsPeriodData()
                        {
                            PeriodID = PeriodId,
                            StartDate = DummyDateTime,
                            FinishDate = DummyDateTime
                        }
                    }
                },
                m_CostTypes = new Dictionary<int, clsDataItem>()
                {
                    {
                        CostTypeId,
                        new clsDataItem()
                        {
                            ID = CostTypeId,
                            UID = CostTypeUId,
                            Name = DummyCostTypeName
                        }
                    }
                },
                m_CustFields = new Dictionary<int, clsCustomFieldData>()
                {
                    {
                        CustomFieldId,
                        new clsCustomFieldData()
                        {
                            FieldID = CustomFieldId,
                            UseFullName = DummyUseFullName,
                            Name = DummyUseName,
                            ListItems = new Dictionary<int, clsListItemData>()
                            {
                                {
                                    ListItemDataId,
                                    new clsListItemData()
                                    {
                                        ID = ListItemDataId,
                                        UID = ListItemDataUid,
                                        Level = ListItemDataLevel,
                                        Name = DummyItemDataName,
                                        FullName = DummyItemDataFullName,
                                        InActive = true
                                    }
                                }
                            }
                        }
                    },
                    {
                        CustomFieldId2,
                        new clsCustomFieldData()
                        {
                            FieldID = CustomFieldId2,
                            UseFullName = DummyUseFullName2,
                            ListItems = new Dictionary<int, clsListItemData>(),
                            Name = DummyUseName2
                        }
                    }
                },
                m_targets = new Dictionary<int, clsDataItem>()
                {
                    {
                        TargetId,
                        new clsDataItem()
                        {
                            UID = TargetUId,
                            Name = DummyTargetName
                        }
                    }
                },
                m_Use_extra = 2,
                m_ExtraFieldNames = new[]
                {
                    DummyExtraFieldName,
                    DummyExtraFieldName2,
                    DummyExtraFieldName3
                },
                m_PIs = new Dictionary<string, clsPIData>()
                {
                    {
                        pisName,
                        new clsPIData(1)
                        {
                            m_PI_Extra_data = piExtraData,
                            m_PI_Format_Extra_data = piFormatExtraData
                        }
                    }
                },
                m_ExtraFieldTypes = extraFieldTypes,
                m_detaildata = new Dictionary<string, clsDetailRowData>()
                {
                    {
                        DummyString,
                        new clsDetailRowData(1)
                        {
                            PROJECT_ID = DetailDataProjectId,
                            Scenario_ID = DetailDataScenarioId,
                            CT_ID = CostTypeId,
                            CT_ind = DetailDataCtInd,
                            bSelected = true,
                            zCost = new double[]
                            {
                                1,
                                DummyZCost
                            }
                        }
                    },
                    {
                        $"{DummyString}2",
                        new clsDetailRowData(1)
                        {
                            PROJECT_ID = DetailDataProjectId,
                            Scenario_ID = DetailDataScenarioId2
                        }
                    }
                },
                m_targetdata = new Dictionary<string, clsDetailRowData>()
                {
                    {
                        DummyString,
                        new clsDetailRowData(1)
                        {
                            CT_ind = 1,
                            zCost = new double[]
                            {
                                1,
                                DummyZCost
                            },
                            zValue = new double[]
                            {
                                3,
                                DummyZValue
                            },
                            zFTE = new double[]
                            {
                                5,
                                DummyZFte
                            },
                            Scenario_ID = DetailRowScenarioId,
                            m_rt = DummyRateId,
                            CT_ID = CostTypeId,
                            BC_UID = DummyCatItemId
                        }
                    }
                },
                m_max_period = DummyMaxPeriod,
                m_clsTargetColours = new List<clsTargetColours>()
                {
                    new clsTargetColours()
                    {
                        ID = DummyTargetColoursId,
                        rgb_val = DummyTargetColoursRgbVal,
                        low_val = DummyTargetColoursLowVal,
                        high_val = DummyTargetColoursHighVal
                    }
                },
                m_CB_ID = DummyCbId,
                m_Rates = new Dictionary<int, clsRateTable>()
                {
                    {
                        DummyRateId,
                        new clsRateTable(1)
                        {
                            ID = DummyRateId
                        }
                    }
                },
                m_CostCat = new Dictionary<int, clsCatItemData>()
                {
                    {
                        DummyCatItemId,
                        new clsCatItemData(1)
                        {
                            Name = DummyCatItemName,
                            FullName = DummyCatItemFullName,
                            MC_Val = DummyMcVal,
                            Role_Name = DummyRoleName,
                            UoM = DummyUom,
                            Category = DummyCatItemId
                        }
                    }
                }
            };
        }
    }
}