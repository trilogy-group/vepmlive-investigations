using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CADataCache;
using CostDataValues;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using Shouldly;

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass, ExcludeFromCodeCoverage]
    public class CostAnalyzerDataCacheTests
    {
        private IDisposable _shimContext;
        private CostAnalyzerDataCache _testEntity;
        private PrivateObject _privateObject;
        private const string CurrentPeriodFieldName = "m_curr_period";
        private const string TopGridColumnsFieldName = "m_topgridcln";
        private const string BottomGridColumnsFieldName = "m_bottomgridcln";
        private const string CtcMpRootFieldName = "m_CTCmpRoot";
        private const string ColumnsSortFieldName = "m_clnsort";
        private const string TotalDetailsFieldName = "m_total_dets";
        private const string TargetDetailsFieldName = "m_target_dets";
        private const string TotalRowsFieldName = "m_total_rows";
        private const string UseQtyFieldName = "bUseQTY";
        private const string ShowFtesFieldName = "bShowFTEs";
        private const string UseCostsFieldName = "bUseCosts";
        private const string ShowRhsDecCostsFieldName = "m_show_rhs_dec_costs";
        private const string HideRowsWithAllZerosFieldName = "_hideRowsWithAllZeros";
        private const string UseHeatMapFieldName = "m_use_heatmap";
        private const string UseHeatMapIdFieldName = "m_use_heatmapID";
        private const string UseHeatMapColourFieldName = "m_use_heatmapColour";
        private const string HeatMapColFieldName = "m_heatmapcol";
        private const string HeatMapTextFieldName = "m_heatmap_text";

        private static readonly DateTime DummyDateTime = new DateTime(2018, 2, 1, 0, 0, 0);
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
        private const string DummyString = "DummyString";
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
        private const string DummyTotalRowsKey = "K 0  0 ";
        private const string DummyFormat = "2";
        private const string DummyTargetId = "190";
        private const string XmlDisplayMode = "<DisplayMode><QTY Value=\"1\" /><FTE Value=\"1\" /><COST Value=\"1\" /><DECOST Value=\"1\" /><HideRowsWithAllZeros Value=\"1\" /></DisplayMode>";
        private const string XmlCompareCostType = "<CTCmpConfiguration><CostType ID=\"111\" Name=\"DummyCostTypeName\" Selected=\"0\" /></CTCmpConfiguration>";
        private const string SetTotalDataXml = "<Node><FIELD ID=\"1\"/><EnableHeatMap Value=\"1\" /><EnableHeatField Value=\"0\"/><SelectedOrderItems><Order ItemId=\"1\" /></SelectedOrderItems> <HeatFieldColour Value=\"1\"/> </Node>";
        private const string ExpectedXmlLegendGrid = "<Grid><Toolbar Visible=\"0\" /><Panel Visible=\"1\" Delete=\"0\" /><Cfg Code=\"GTACCNPSQEBSLC\" FilterEmpty=\"1\" SuppressMessage=\"3\" NoTreeLines=\"1\" MaxHeight=\"0\" ShowDeleted=\"0\" Deleting=\"0\" Selecting=\"0\" Dragging=\"0\" DragEdit=\"0\" MaxWidth=\"1\" HideHScroll=\"1\" SelectingCells=\"1\" DateStrings=\"1\" AppendId=\"0\" FullId=\"0\" IdChars=\"0123456789\" NumberId=\"1\" Style=\"GM\" CSS=\"ResPlanAnalyzer\" IdPrefix=\"R\" IdPostfix=\"x\" CaseSensitiveId=\"0\" /><LeftCols><C /><C Name=\"Key\" Type=\"Text\" Width=\"400\" CanEdit=\"0\" /></LeftCols><Header Visible=\"0\" Key=\" \" /><Body><B /><I Grouping=\"Totals\" CanEdit=\"0\"><I CanEdit=\"0\" NoColorState=\"1\" Key=\"\" KeyColor=\"RGB(161,0,0)\" /></I></Body></Grid>";
        private const string ExpectedTargetTotalsData = "<TargetTotalData><targetRows CT_ID=\"0\" BC_UID=\"0\" BC_ROLE_UID=\"0\" BC_SEQ=\"0\" CAT_UID=\"0\" MC_Val=\"\" CT_Name=\"\" Cat_Name=\"\" Role_Name=\"\" MC_Name=\"\" FullCatName=\"\" CC_Name=\"\" FullCCName=\"\" m_rt=\"0\"><OCVal Value=\"0\" /><Text_OCVal Value=\"\" /><TXVal Value=\"\" /><OCVal Value=\"0\" /><Text_OCVal Value=\"\" /><TXVal Value=\"\" /><OCVal Value=\"0\" /><Text_OCVal Value=\"\" /><TXVal Value=\"\" /><OCVal Value=\"0\" /><Text_OCVal Value=\"\" /><TXVal Value=\"\" /><OCVal Value=\"0\" /><Text_OCVal Value=\"\" /><TXVal Value=\"\" /><OCVal Value=\"0\" /><Text_OCVal Value=\"\" /><TXVal Value=\"\" /><zCost Value=\"0\" /><zValue Value=\"0\" /><zFTE Value=\"0\" /><zCost Value=\"0\" /><zValue Value=\"0\" /><zFTE Value=\"0\" /></targetRows></TargetTotalData>";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testEntity = new CostAnalyzerDataCache();
            _privateObject = new PrivateObject(_testEntity);

            ShimDateTime.NowGet = () => DummyDateTime;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
        }

        [TestMethod]
        public void GrabCAData_Should_FillProperties()
        {
            // Arrange
            var expectedTopBottomGridColumns = new List<string>()
            {
                "Portfolio Item",
                "Cost Types",
                "Cost Categories",
                "Category",
                "Role",
                "Full Category",
                "Total Cost",
                "Display Cost"
            };

            var expectedTopGridColumns = new List<string>()
            {
                "Start",
                "Finish",
                "Major Category",
                "Full Cost Category"
            };

            // Act
            _testEntity.GrabCAData(CreateCostData());

            // Assert
            var currentPeriod = (int)_privateObject.GetField(CurrentPeriodFieldName);
            var topGridColumns = (List<clsColDisp>)_privateObject.GetField(TopGridColumnsFieldName);
            var bottomGridColumns = (List<clsColDisp>)_privateObject.GetField(BottomGridColumnsFieldName);
            var ctcMpRoot = ((List<clsDataItem>)_privateObject.GetField(CtcMpRootFieldName))[0];
            var columnsSort = ((List<clsDetailRowData>)_privateObject.GetField(ColumnsSortFieldName))[0];
            var totalDetails = (Dictionary<string, clsDetailRowData>)_privateObject.GetField(TotalDetailsFieldName);
            var targetDetails = (Dictionary<string, clsDetailRowData>)_privateObject.GetField(TargetDetailsFieldName);
            var totalRows = (Dictionary<string, CATotRow>)_privateObject.GetField(TotalRowsFieldName);

            this.ShouldSatisfyAllConditions(
                () => currentPeriod.ShouldBe(PeriodId),
                () => expectedTopGridColumns.ForEach(p => topGridColumns.FirstOrDefault(x => x.m_realname == p).ShouldNotBeNull()),
                () => expectedTopBottomGridColumns.ForEach(p => topGridColumns.FirstOrDefault(x => x.m_realname == p).ShouldNotBeNull()),
                () => expectedTopBottomGridColumns.ForEach(p => bottomGridColumns.FirstOrDefault(x => x.m_realname == p).ShouldNotBeNull()),
                () => ctcMpRoot.ID.ShouldBe(CostTypeId),
                () => ctcMpRoot.Name.ShouldBe(DummyCostTypeName),
                () => ctcMpRoot.UID.ShouldBe(CostTypeUId),
                () => columnsSort.PROJECT_ID.ShouldBe(DetailDataProjectId),
                () => columnsSort.Scenario_ID.ShouldBe(DetailDataScenarioId),
                () => columnsSort.m_PI_Format_Extra_data[1].ShouldBe(DummyFormat),
                () => totalDetails.Count.ShouldBe(2),
                () => targetDetails.Count.ShouldBe(2),
                () => totalRows.Count.ShouldBe(2));
        }

        [TestMethod]
        public void GetPeriodsData_PeriodFilled_ReturnsString()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            // Act
            var actualResult = _testEntity.GetPeriodsData();

            // Assert
            actualResult.ShouldBe($"<Periods><CurrentPeriod Value=\"{PeriodId}\" /><Period perID=\"{PeriodId}\" perName=\"\" /></Periods>");
        }

        [TestMethod]
        public void GetPeriodsData_PeriodNull_ReturnsEmptyString()
        {
            // Arrange, Act
            var actualResult = _testEntity.GetPeriodsData();

            // Assert
            actualResult.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetCostTypeNameData_CostTypeFilled_ReturnsString()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            // Act
            var actualResult = _testEntity.GetCostTypeNameData();

            // Assert
            actualResult.ShouldBe($"<CostTypes><CostType ID=\"{CostTypeUId}\" Name=\"{DummyCostTypeName}\" Sel=\"1\" Event=\"zCT{CostTypeUId}\" ButtonID=\"chkCT{CostTypeUId}\" /></CostTypes>");
        }

        [TestMethod]
        public void GetCostTypeNameData_CostTypeNull_ReturnsEmptyString()
        {
            // Arrange, Act
            var actualResult = _testEntity.GetCostTypeNameData();

            // Assert
            actualResult.ShouldBe(string.Empty);
        }

        [TestMethod]
        public void GetTopGrid_TopGridFilled_ReturnsString()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            var expectedContents = new List<string>()
            {
                $"<C Name=\"zX{DummyUseName}\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" />",
                $"<C Name=\"zX{DummyUseName2}\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" />",
                $"<C Name=\"zX{DummyExtraFieldName2}\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" />",
                $"<C Name=\"zX{DummyExtraFieldName3}\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" Visible=\"0\" />",
                $"<Header PortfolioItemVisible=\"1\" Spanned=\"-1\" SortIcons=\"0\" HoverCell=\"Color\" HoverRow=\"\" RowSel=\" \" Select=\" \" zXPortfolioItem=\" \" zXStart=\" \" zXFinish=\" \" zXCostTypes=\" \" zXCostCategories=\" \" zXCategory=\" \" zXRole=\" \" zXMajorCategory=\" \" zXFullCostCategory=\" \" zXFullCategory=\" \" zXTotalCost=\" \" zXDisplayCost=\" \" zX{DummyUseName}=\" \" zX{DummyUseName2}=\" \" zX{DummyExtraFieldName2}=\" \" zX{DummyExtraFieldName3}=\" \" P100C1=\"Cost\" />"
            };

            // Act
            var actualResult = _testEntity.GetTopGrid();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void GetBottomGrid_BottomGridFilled_ReturnsString()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            var expectedContents = new List<string>()
            {
                $"<C Name=\"zX{DummyUseName}\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Visible=\"0\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" />",
                $"<C Name=\"zX{DummyUseName2}\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Visible=\"0\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" />",
                $"<C Name=\"zX{DummyExtraFieldName2}\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Visible=\"0\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" />",
                $"<C Name=\"zX{DummyExtraFieldName3}\" Class=\"GMCellMain\" CanDrag=\"0\" ShowHint=\"0\" CaseSensitive=\"0\" OnDragCell=\"Focus,DragCell\" Visible=\"0\" Type=\"Text\" CanEdit=\"0\" CanMove=\"1\" />",
                $"<Header PortfolioItemVisible=\"1\" Spanned=\"-1\" SortIcons=\"0\" HoverCell=\"Color\" HoverRow=\"\" zXPortfolioItem=\" \" zXCostTypes=\" \" zXCostCategories=\" \" zXCategory=\" \" zXRole=\" \" zXFullCategory=\" \" zXTotalCost=\" \" zXDisplayCost=\" \" zX{DummyUseName}=\" \" zX{DummyUseName2}=\" \" zX{DummyExtraFieldName2}=\" \" zX{DummyExtraFieldName3}=\" \" P100C1=\"Totals\" />"
            };

            // Act
            var actualResult = _testEntity.GetBottomGrid();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void SetDisplayMode_Should_SetFieldsTrue()
        {
            // Arrange
            var dataDisplay = new CStruct();
            dataDisplay.LoadXML(XmlDisplayMode);

            // Act
            _testEntity.SetDisplayMode(dataDisplay);

            // Arrange
            var useQty = (bool)_privateObject.GetField(UseQtyFieldName);
            var showFTes = (bool)_privateObject.GetField(ShowFtesFieldName);
            var useCosts = (bool)_privateObject.GetField(UseCostsFieldName);
            var shoRhsDecCosts = (bool)_privateObject.GetField(ShowRhsDecCostsFieldName);
            var hideRowsWithAllZeros = (bool)_privateObject.GetField(HideRowsWithAllZerosFieldName);

            this.ShouldSatisfyAllConditions(
                () => useQty.ShouldBeTrue(),
                () => showFTes.ShouldBeTrue(),
                () => useCosts.ShouldBeTrue(),
                () => shoRhsDecCosts.ShouldBeTrue(),
                () => hideRowsWithAllZeros.ShouldBeTrue());
        }

        [TestMethod]
        public void GetDisplayMode_Should_ReturnsXml()
        {
            // Arrange
            var dataDisplay = new CStruct();
            dataDisplay.LoadXML(XmlDisplayMode);
            _testEntity.SetDisplayMode(dataDisplay);

            // Act
            var actualResult = _testEntity.GetDisplayMode();

            // Assert
            actualResult.ShouldBe(XmlDisplayMode);
        }

        [TestMethod]
        public void GetLegendGrid__Should_ReturnsXml()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            // Act
            var actualResult = _testEntity.GetLegendGrid();

            // Assert
            actualResult.ShouldBe(ExpectedXmlLegendGrid);
        }

        [TestMethod]
        public void GetTotalsData_Should_ReturnsXml()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            var expectedContents = new List<string>()
            {
                "<FIELD ID=\"1\" Name=\"Portfolio Items\" Selected=\"1\" />",
                "<FIELD ID=\"2\" Name=\"Cost Types\" Selected=\"0\" />",
                "<FIELD ID=\"4\" Name=\"Cost Categories\" Selected=\"1\" />",
                "<FIELD ID=\"11\" Name=\"Category\" Selected=\"0\" />",
                "<FIELD ID=\"8\" Name=\"Role\" Selected=\"0\" />",
                "<ColumnOption ColumnID=\"0\" Selected=\"1\" Name=\"Totals (from Top Grid)\" />",
                $"<ColumnOption ColumnID=\"{CostTypeUId}\" Selected=\"0\" Name=\"{DummyCostTypeName}\" />",
                $"<ColumnOption ColumnID=\"-{TargetUId}\" Selected=\"0\" Name=\"{DummyTargetName}\" />"
            };

            // Act
            var actualResult = _testEntity.GetTotalsData();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void SetTotalsData_Should_FillProperties()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            var dataDisplay = new CStruct();
            dataDisplay.LoadXML(SetTotalDataXml);

            // Act
            _testEntity.SetTotalsData(dataDisplay);

            // Assert
            var useHeatMap = (bool)_privateObject.GetField(UseHeatMapFieldName);
            var useHeatMapId = (int)_privateObject.GetField(UseHeatMapIdFieldName);
            var useHeatMapColour = (int)_privateObject.GetField(UseHeatMapColourFieldName);
            var heatMapCol = (int)_privateObject.GetField(HeatMapColFieldName);
            var heatMapText = (string)_privateObject.GetField(HeatMapTextFieldName);

            this.ShouldSatisfyAllConditions(
                () => useHeatMap.ShouldBeTrue(),
                () => useHeatMapId.ShouldBe(0),
                () => useHeatMapColour.ShouldBe(1),
                () => heatMapCol.ShouldBe(0),
                () => heatMapText.ShouldBe("Totals"));
        }

        [TestMethod]
        public void SetCompareCostType_Should_ReturnsXml()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            var xml = $"<Node><Item ID=\"{CostTypeUId}\"></Item></Node>";

            var dataDisplay = new CStruct();
            dataDisplay.LoadXML(xml);

            // Act
            var actualResult = _testEntity.SetCompareCostType(dataDisplay);

            // Arrange
            actualResult.ShouldBe($"<HeatMapText Value=\"{DummyCostTypeName}\" />");
        }

        [TestMethod]
        public void GetCompareCostTypeList_Should_ReturnsXml()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            // Act
            var actualResult = _testEntity.GetCompareCostTypeList();

            // Assert
            actualResult.ShouldBe(XmlCompareCostType);
        }

        [TestMethod]
        public void GetTargetList_Should_ReturnsXml()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            // Act
            var actualResult = _testEntity.GetTargetList();

            // Assert
            actualResult.ShouldBe($"<Targets><Target Name=\"{DummyTargetName}\" ID=\"{TargetUId}\" /></Targets>");
        }

        [TestMethod]
        public void RatesAndCategory_Should_ReturnsXml()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            var expectedContents = new List<string>()
            {
                $"<Category ID=\"0\" UID=\"0\" Level=\"0\" Role_UID=\"0\" MC_UID=\"0\" Category=\"{DummyCatItemId}\" Name=\"{DummyCatItemName}\" UoM=\"{DummyUom}\" FullName=\"{DummyCatItemFullName}\" MC_Val=\"{DummyMcVal}\" Role_Name=\"{DummyRoleName}\">",
                $"<CostType Id=\"{CostTypeUId}\" Name=\"{DummyCostTypeName}\" />",
                $"<CustomField FieldID=\"{CustomFieldId}\" Name=\"z{DummyUseName}\" LookupOnly=\"0\" LookupID=\"0\" LeafOnly=\"0\" UseFullName=\"{DummyUseFullName}\" jsonMenu=\"{{Items:[{{Name:'{ListItemDataId}',Text:'{DummyItemDataName}',Value:'{ListItemDataUid}'}}]}}\">",
                $"<LookUp ID=\"{ListItemDataId}\" UID=\"{ListItemDataUid}\" Level=\"{ListItemDataLevel}\" Name=\"{DummyItemDataName}\" FullName=\"{DummyItemDataFullName}\" InActive=\"1\" />",
                $"<CustomField FieldID=\"{CustomFieldId2}\" Name=\"z{DummyUseName2}\" LookupOnly=\"0\" LookupID=\"0\" LeafOnly=\"0\" UseFullName=\"121\" jsonMenu=\"\">",
                $"<Period ID=\"{PeriodId}\" Name=\"\" />"
            };

            // Act
            var actualResult = _testEntity.RatesAndCategory();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void PrepareTargetData_Should_ReturnsXml()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            var expectedContents = new List<string>()
            {
                $"<targetRows RID=\"1\" CT_ID=\"{CostTypeId}\" BC_UID=\"{DummyCatItemId}\" BC_ROLE_UID=\"0\" BC_SEQ=\"0\" CAT_UID=\"0\" MC_Val=\"\" CT_Name=\"{DummyCostTypeName}\" Cat_Name=\"{DummyCatItemName}\" Role_Name=\"{DummyRoleName}\" MC_Name=\"{DummyMcVal}\" FullCatName=\"{DummyCatItemFullName}\" CC_Name=\"{DummyCatItemName}\" FullCCName=\"{DummyCatItemFullName}\" m_rt=\"0\">",
                $"<zCost Value=\"{DummyZCost}\" />",
                $"<zValue Value=\"{DummyZValue}\" />"
            };

            // Act
            var actualResult = _testEntity.PrepareTargetData(DummyTargetId);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void GetTargetGrid_TargetTotalsDataFilled_ReturnsString()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());
            _testEntity.PrepareTargetData(DummyTargetId);

            var expectedContents = new List<string>()
            {
                $"<C Name=\"z{DummyUseName}\" CanEdit=\"0\" Defaults=\"\" />",
                $"<C Name=\"z{DummyUseName2}\" CanEdit=\"0\" Defaults=\"\" />",
                "<C Name=\"P1V\" Type=\"Float\" CanMove=\"0\" Format=\"0.###\" />",
                $"<D Name=\"Leaf\" Calculated=\"0\" HoverCell=\"Color\" HoverRow=\"Color\" FocusCell=\"\" OnFocus=\"ClearSelection+Grid.SelectRow(Row,!Row.Selected)\" NoColorState=\"1\" SelectCanEdit=\"1\" CostTypeHtmlPrefix=\"\" CostTypeHtmlPostfix=\"\" CostTypeCanEdit=\"0\" CostCategoryHtmlPrefix=\"\" CostCategoryHtmlPostfix=\"\" CostCategoryCanEdit=\"0\" MajorCategoryHtmlPrefix=\"\" MajorCategoryHtmlPostfix=\"\" MajorCategoryCanEdit=\"0\" RoleHtmlPrefix=\"\" RoleHtmlPostfix=\"\" RoleCanEdit=\"0\" NamedRateHtmlPrefix=\"\" NamedRateHtmlPostfix=\"\" NamedRateCanEdit=\"0\" z{DummyUseName}HtmlPrefix=\"\" z{DummyUseName}HtmlPostfix=\"\" z{DummyUseName}CanEdit=\"0\" z{DummyUseName2}HtmlPrefix=\"\" zDummyUseName2HtmlPostfix=\"\" z{DummyUseName2}CanEdit=\"0\" P1VFormula=\"\" P1CFormula=\"\" />",
                $"<Header Spanned=\"-1\" SortIcons=\"0\" Select=\" \" rowid=\" \" CostType=\"Cost\" CostCategory=\"Cost\" MajorCategory=\"Major\" Role=\" \" NamedRate=\"Named \" z{DummyUseName}=\" \" z{DummyUseName2}=\" \" P1VSpan=\"2\" P1V=\"\" />",
                $"<I id=\"1\" rowid=\"1\" Def=\"Leaf\" CostType=\"{DummyCostTypeName}\" CostCategory=\"{DummyCatItemFullName}\" CostTypeButton=\"Defaults\" CostCategoryButton=\"Defaults\" MajorCategory=\"{DummyMcVal}\" MajorCategoryCanEdit=\"0\" Role=\"{DummyRoleName}\" RoleCanEdit=\"0\" NamedRate=\"\" z{DummyUseName}=\"\" z{DummyUseName}Button=\"Defaults\" z{DummyUseName2}=\"\" z{DummyUseName2}Button=\"Defaults\" NoColorState=\"1\" P0V=\"0\" P0C=\"0\" P0VCanEdit=\"0\" P0CCanEdit=\"1\" P1V=\"151\" P1C=\"150\" P1VCanEdit=\"0\" P1CCanEdit=\"1\" />"
            };

            // Act
            var actualResult = _testEntity.GetTargetGrid();

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualResult.ShouldNotBeNullOrEmpty(),
                () => expectedContents.ForEach(c => actualResult.ShouldContain(c)));
        }

        [TestMethod]
        public void GetTargetTotalsData_TargetTotalsDataFilled_ReturnsString()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            var totalRows = (Dictionary<string, CATotRow>)_privateObject.GetField(TotalRowsFieldName);
            totalRows[DummyTotalRowsKey].bUsed = true;

            _privateObject.SetField(TotalRowsFieldName, totalRows);

            // Act
            var actualResult = _testEntity.GetTargetTotalsData();

            // Assert
            actualResult.ShouldBe(ExpectedTargetTotalsData);
        }

        [TestMethod]
        public void GetCbId_Should_ReturnsMaxPeriods()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            // Act
            var actualResult = _testEntity.Get_CB_ID();

            // Assert
            actualResult.ShouldBe(DummyCbId);
        }

        [TestMethod]
        public void GetMaxPeriods_Should_ReturnsMaxPeriods()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            // Act
            var actualResult = _testEntity.Get_MaxPeriods();

            // Assert
            actualResult.ShouldBe(DummyMaxPeriod);
        }

        [TestMethod]
        public void GetTargetRGBData_PropertiesFilled_ReturnsString()
        {
            // Arrange
            _testEntity.GrabCAData(CreateCostData());

            // Act
            var actualResult = _testEntity.GetTargetRGBData();

            // Assert
            actualResult.ShouldBe($"<Targets><Target ID=\"{DummyTargetColoursId}\" RGB=\"{DummyTargetColoursRgbVal}\" Lowval=\"{DummyTargetColoursLowVal}\" Hival=\"{DummyTargetColoursHighVal}\" /><MaxTargetID Value=\"{DummyTargetColoursId}\" /></Targets>");
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
                            Name = DummyCostTypeName,
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
                        high_val = DummyTargetColoursHighVal,
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
