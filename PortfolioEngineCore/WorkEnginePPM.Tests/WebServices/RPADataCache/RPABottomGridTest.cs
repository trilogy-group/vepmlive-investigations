using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPMLiveCore.Infrastructure.Logging.Fakes;
using Global.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using ResourceValues;
using RPADataCache;
using WorkEnginePPM.Tests.TestDoubles.RPADataCache;

namespace WorkEnginePPM.Tests.WebServices.RPADataCache
{
    [TestClass]
    public class RPABottomGridTest
    {
        private IDisposable _shimsContext;

        private bool _useRole;
        private string _roleHeader;
        private bool _useHeatMap;
        private int _heatMapId;
        private int _heatMapColor;
        private bool _doZeroRowCleverStuff;
        private bool _displayTotalsDetails;
        private Func<int, string> _resolvePiNameFunc;
        private Func<CPeriod, string> _resolvePeriodNameFunc;
        private IList<clsRXDisp> _columns;
        private int _displayMode;
        private IList<RPATGRow> _displayList;
        private clsResourceValues _resourceValues;
        private GridRenderingTypes _renderingType;
        private RPABottomGridTestDouble _testDouble;

        private ICollection<string> _substructsCreated;
        private IDictionary<string, IDictionary<string, string>> _stringAttributesCreated;
        private IDictionary<string, IDictionary<string, bool>> _booleanAttributesCreated;
        private IDictionary<string, IDictionary<string, int>> _intAttributesCreated;
        private IDictionary<string, IDictionary<string, double>> _doubleAttributesCreated;

        private IList<CPeriod> _periods;
        private clsResFullDAta _detailRow;
        private int _rowId;

        private IList<string> _errorsLogged;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            SetUpDefaultValues();

            _testDouble = CreateTestDouble();

            ShimCStruct();

            _errorsLogged = new List<string>();
            ShimLoggingService.WriteTraceStringStringTraceSeverityString = (area, category, severity, text) =>
            {
                _errorsLogged.Add(text);
            };
        }

        private void SetUpDefaultValues()
        {
            _renderingType = GridRenderingTypes.Combined;

            _useRole = true;
            _roleHeader = "test-header";
            _useHeatMap = true;
            _heatMapId = 1;
            _heatMapColor = 2;
            _doZeroRowCleverStuff = true;
            _displayTotalsDetails = true;
            _resolvePiNameFunc = new Func<int, string>(number => "test-pi-name");
            _resolvePeriodNameFunc = new Func<CPeriod, string>(period => "test-period-name");

            _columns = new[]
            {
                new clsRXDisp { m_id = RPConstants.TGRID_TOTRESRES_ID, m_realname = "test-real-name-1 /n\r\n", m_dispname = "test-name-1 /n\r\n", },
                new clsRXDisp { m_id = RPConstants.TGRID_TOTITEM_ID, m_realname = "test-real-name-2 /n\r\n", m_dispname = "test-name-2 /n\r\n" }
            };
            _displayList = new[]
            {
                new RPATGRow { bUse = true }
            };
            _periods = new[] {
                new CPeriod
                {
                    PeriodID = 1,
                    PeriodName = "test-1"
                },
                new CPeriod
                {
                    PeriodID = 2,
                    PeriodName = "test-2"
                }
            };
            
            _displayMode = 0;
            _resourceValues = new clsResourceValues
            {
                Periods = _periods.ToDictionary(pred => pred.PeriodID, pred => pred)
            };

            _detailRow = new clsResFullDAta();
            _rowId = 3;
        }

        private void ShimCStruct()
        {
            _substructsCreated = new HashSet<string>();
            _stringAttributesCreated = new Dictionary<string, IDictionary<string, string>>();
            _booleanAttributesCreated = new Dictionary<string, IDictionary<string, bool>>();
            _intAttributesCreated = new Dictionary<string, IDictionary<string, int>>();
            _doubleAttributesCreated = new Dictionary<string, IDictionary<string, double>>();

            PortfolioEngineCore.Fakes.ShimCStruct.AllInstances.CreateSubStructString = (instance, subStructName) =>
            {
                _substructsCreated.Add(subStructName);

                return new ShimCStruct
                {
                    NameGet = () => subStructName
                };
            };

            PortfolioEngineCore.Fakes.ShimCStruct.AllInstances.CreateStringAttrStringString = (element, name, value) =>
            {
                if (!_stringAttributesCreated.ContainsKey(element.Name))
                {
                    _stringAttributesCreated[element.Name] = new Dictionary<string, string>();
                }

                _stringAttributesCreated[element.Name][name] = value;
            };
            PortfolioEngineCore.Fakes.ShimCStruct.AllInstances.CreateBooleanAttrStringBoolean = (element, name, value) =>
            {
                if (!_booleanAttributesCreated.ContainsKey(element.Name))
                {
                    _booleanAttributesCreated[element.Name] = new Dictionary<string, bool>();
                }

                _booleanAttributesCreated[element.Name][name] = value;
            };
            PortfolioEngineCore.Fakes.ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (element, name, value) =>
            {
                if (!_intAttributesCreated.ContainsKey(element.Name))
                {
                    _intAttributesCreated[element.Name] = new Dictionary<string, int>();
                }

                _intAttributesCreated[element.Name][name] = value;
            };
            PortfolioEngineCore.Fakes.ShimCStruct.AllInstances.CreateDoubleAttrStringDouble = (element, name, value) =>
            {
                if (!_doubleAttributesCreated.ContainsKey(element.Name))
                {
                    _doubleAttributesCreated[element.Name] = new Dictionary<string, double>();
                }

                _doubleAttributesCreated[element.Name][name] = value;
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        private RPABottomGridTestDouble CreateTestDouble()
        {
            return new RPABottomGridTestDouble(
                _useRole,
                _roleHeader,
                _useHeatMap,
                _heatMapId,
                _heatMapColor,
                _doZeroRowCleverStuff,
                _displayTotalsDetails,
                _resolvePiNameFunc,
                _resolvePeriodNameFunc,
                _columns,
                _displayMode,
                _displayList,
                _resourceValues
            );
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InitializeGridLayout_RenderingTypeNone_Throws()
        {
            // Arrange
            _renderingType = GridRenderingTypes.None;

            // Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            // ExpectedException - ArgumentException
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesLayoutConfigToolbar()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Toolbar"));
            Assert.AreEqual(0, _intAttributesCreated["Toolbar"]["Visible"]);
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesLayoutConfigPanel()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Panel"));
            Assert.AreEqual(0, _intAttributesCreated["Panel"]["Visible"]);
            Assert.AreEqual(0, _intAttributesCreated["Panel"]["Select"]);
            Assert.AreEqual(0, _intAttributesCreated["Panel"]["Delete"]);
            Assert.AreEqual(0, _intAttributesCreated["Panel"]["CanHide"]);
            Assert.AreEqual(0, _intAttributesCreated["Panel"]["CanSelect"]);
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesLayoutConfigCfg()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Cfg"));
            Assert.AreEqual("ResOrRole", _stringAttributesCreated["Cfg"]["MainCol"]);
            Assert.AreEqual("GTACCNPSQEBSLC", _stringAttributesCreated["Cfg"]["Code"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["SuppressCfg"]);
            Assert.AreEqual(3, _intAttributesCreated["Cfg"]["SuppressMessage"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["PrintCols"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["Dragging"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["Sorting"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["ColsMoving"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["ColsPosLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["ColsLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["VisibleLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["SectionWidthLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["GroupLap"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["WideHScroll"]);
            Assert.AreEqual(400, _intAttributesCreated["Cfg"]["LeftWidth"]);
            Assert.AreEqual(400, _intAttributesCreated["Cfg"]["Width"]);
            Assert.AreEqual(400, _intAttributesCreated["Cfg"]["RightWidth"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["MaxHeight"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["ShowDeleted"]);
            Assert.AreEqual(true, _booleanAttributesCreated["Cfg"]["DateStrings"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["MaxWidth"]);
            Assert.AreEqual(2, _intAttributesCreated["Cfg"]["MaxSort"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["AppendId"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["FullId"]);
            Assert.AreEqual("0123456789", _stringAttributesCreated["Cfg"]["IdChars"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["NumberId"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["LastId"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["CaseSensitiveId"]);
            Assert.AreEqual("GM", _stringAttributesCreated["Cfg"]["Style"]);
            Assert.AreEqual("ResPlanAnalyzer", _stringAttributesCreated["Cfg"]["CSS"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["FastColumns"]);
            Assert.AreEqual(3, _intAttributesCreated["Cfg"]["ExpandAllLevels"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["GroupSortMain"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["GroupRestoreSort"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["NoTreeLines"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["ShowVScroll"]);
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesColumns()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("LeftCols"));
            Assert.IsTrue(_substructsCreated.Contains("Cols"));
            Assert.IsTrue(_substructsCreated.Contains("RightCols"));
            Assert.AreEqual("RightCols", _testDouble.PeriodCols.Name);
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesDefinitions()
        {
            // Arrange
            var definitionsInitialized = new List<string>();
            ShimGridBase<CPeriod, clsResFullDAta>.AllInstances.InitializeGridLayoutDefinitionStringCStructNullableOfBoolean = (instance, name, definitions, a) =>
            {
                definitionsInitialized.Add(name);
                return new PortfolioEngineCore.CStruct();
            };

            // Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.AreEqual(3, definitionsInitialized.Count);
            Assert.IsTrue(definitionsInitialized.Contains("R"));
            Assert.AreEqual(2, definitionsInitialized.Count(pred => pred == "Leaf"));
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesHeaders()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Head"));
            Assert.IsTrue(_substructsCreated.Contains("Filter"));
            Assert.AreEqual("Filter", _stringAttributesCreated["Filter"]["id"]);
            Assert.AreEqual(1, _intAttributesCreated["Header"]["PortfolioItemVisible"]);
            Assert.AreEqual(1, _intAttributesCreated["Header"]["NoEscape"]);
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesCategoryColumns()
        {
            // Arrange
            var nameAttributeValues = new HashSet<string>();
            var typeAttributeValues = new HashSet<string>();
            PortfolioEngineCore.Fakes.ShimCStruct.AllInstances.CreateStringAttrStringString = (element, name, value) =>
            {
                if (name == "Name")
                {
                    nameAttributeValues.Add(value);
                }
                if (name == "Type")
                {
                    typeAttributeValues.Add(value);
                }
            };

            // Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(nameAttributeValues.Contains("RowSel"));
            Assert.IsTrue(typeAttributeValues.Contains("Icon"));
            Assert.IsTrue(nameAttributeValues.Contains("rowid"));
            Assert.IsTrue(typeAttributeValues.Contains("Text"));
            Assert.IsTrue(nameAttributeValues.Contains("Select"));
            Assert.IsTrue(typeAttributeValues.Contains("Bool"));
            Assert.IsTrue(nameAttributeValues.Contains("ChangedIcon"));
            Assert.IsTrue(typeAttributeValues.Contains("Type"));
            Assert.IsTrue(nameAttributeValues.Contains("RowDraggable"));
            Assert.IsTrue(typeAttributeValues.Contains("Bool"));
            Assert.IsTrue(nameAttributeValues.Contains("RowChanged"));
            Assert.IsTrue(typeAttributeValues.Contains("Int"));
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesViewColumns()
        {
            // Arrange
            var nameAttributeValues = new HashSet<string>();
            PortfolioEngineCore.Fakes.ShimCStruct.AllInstances.CreateStringAttrStringString = (element, name, value) =>
            {
                if (name == "Name")
                {
                    nameAttributeValues.Add(value);
                }
            };

            // Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            foreach (var column in _columns)
            {
                Assert.IsTrue(nameAttributeValues.Contains(column.m_realname
                    .Replace(" ", string.Empty)
                    .Replace("\r", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace("/n", string.Empty)
                ));
            }
        }

        [TestMethod]
        public void ResolvePeriodId_Always_ReturnsPeriodId()
        {
            // Arrange
            var periodData = new CPeriod
            {
                PeriodID = 2
            };

            // Act
            var result = _testDouble.ResolvePeriodId(periodData, 10);

            // Assert
            Assert.AreEqual(periodData.PeriodID.ToString(), result);
        }

        [TestMethod]
        public void AddPeriodColumns_DisplayRowsInUse_ProcessesEachPeriod()
        {
            // Arrange, Act
            _testDouble.AddPeriodColumns(_periods);

            // Assert
            foreach (var period in _periods)
            {
                Assert.AreEqual(period.PeriodName, _stringAttributesCreated["Header"]["P" + period.PeriodID + "C1"]);
            }
        }

        [TestMethod]
        public void AddPeriodColumns_DisplayRowsInUse_HeaderAttributesSet()
        {
            // Arrange, Act
            _testDouble.AddPeriodColumns(_periods);

            // Assert
            foreach (var period in _periods)
            {
                Assert.AreEqual(period.PeriodName, _stringAttributesCreated["Header"]["P" + period.PeriodID + "C1"]);
            }
        }

        [TestMethod]
        public void AddPeriodColumns_DisplayRowsInUse_CategoryColumnGeneratedForEachDisplayRow()
        {
            // Arrange
            var nameAttributeValues = new HashSet<string>();
            PortfolioEngineCore.Fakes.ShimCStruct.AllInstances.CreateStringAttrStringString = (element, name, value) =>
            {
                if (name == "Name")
                {
                    nameAttributeValues.Add(value);
                }
            };

            // Act
            _testDouble.AddPeriodColumns(_periods);

            // Assert
            foreach (var period in _periods)
            {
                for (var i = 1; i <= _displayList.Count; i++)
                {
                    Assert.IsTrue(nameAttributeValues.Contains(
                        "P" + period.PeriodID + "C" + i
                    ));
                }
            }
        }

        [TestMethod]
        public void AddPeriodColumns_DisplayRowsInUseDefaultSettings_SetsBasicContainerAttributes()
        {
            // Arrange, Act
            _testDouble.AddPeriodColumns(_periods);

            // Assert
            Assert.AreEqual(",0.##", _stringAttributesCreated["C"]["Format"]);
            Assert.AreEqual("Right", _stringAttributesCreated["C"]["Align"]);
            Assert.AreEqual(45, _intAttributesCreated["C"]["MinWidth"]);
            Assert.AreEqual(65, _intAttributesCreated["C"]["Width"]);
        }

        [TestMethod]
        public void AddPeriodColumns_DisplayRowsInUseDefaultSettings_SetsDefinitionsAttributes()
        {
            // Arrange, Act
            _testDouble.AddPeriodColumns(_periods);

            // Assert
            foreach (var period in _periods)
            {
                for (var i = 1; i <= _displayList.Count; i++)
                {
                    var prefix = "P" + period.PeriodID + "C" + i;
                    Assert.AreEqual(string.Empty, _stringAttributesCreated["Leaf"][prefix + "Formula"]);
                    Assert.AreEqual(string.Empty, _stringAttributesCreated["Right"][prefix + "ClassInner"]);
                    Assert.AreEqual(string.Empty, _stringAttributesCreated["Leaf"][prefix + "ClassInner"]);
                    Assert.AreEqual(string.Empty, _stringAttributesCreated["Right"][prefix + "HtmlPostfix"]);
                    Assert.AreEqual(string.Empty, _stringAttributesCreated["Leaf"][prefix + "HtmlPostfix"]);
                    Assert.AreEqual(string.Empty, _stringAttributesCreated["Right"][prefix + "HtmlPrefix"]);
                    Assert.AreEqual(string.Empty, _stringAttributesCreated["Leaf"][prefix + "HtmlPrefix"]);
                }
            }
        }

        [TestMethod]
        public void InitializeGridData_Always_CreatesCorrectStructure()
        {
            // Arrange, Act
            _testDouble.InitializeGridData(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Body"));
            Assert.IsTrue(_substructsCreated.Contains("B"));
            Assert.IsTrue(_substructsCreated.Contains("I"));
            Assert.AreEqual("Totals", _stringAttributesCreated["I"]["Grouping"]);
            Assert.AreEqual(false, _booleanAttributesCreated["I"]["CanEdit"]);

            Assert.AreEqual(0, _testDouble.Level);
            Assert.AreEqual("I", _testDouble.Levels[_testDouble.Level].Name);
        }

        [TestMethod]
        public void CheckIfDetailRowShouldBeAdded_Always_ReturnsTrue()
        {
            // Arrange
            clsResFullDAta detailRow = null;

            // Act
            var result = _testDouble.CheckIfDetailRowShouldBeAdded(detailRow);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddDetailRow_Always_CreatesCorrectStructure()
        {
            // Arrange, Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("I"));
            Assert.AreEqual(_rowId.ToString(), _stringAttributesCreated["I"]["id"]);
            Assert.AreEqual("white", _stringAttributesCreated["I"]["Color"]);
            Assert.AreEqual("Leaf", _stringAttributesCreated["I"]["Def"]);
            Assert.AreEqual(_rowId, _intAttributesCreated["I"]["rowid"]);
            Assert.AreEqual(1, _intAttributesCreated["I"]["NoColorState"]);
            Assert.AreEqual(false, _booleanAttributesCreated["I"]["CanEdit"]);
            Assert.AreEqual(true, _booleanAttributesCreated["I"]["rtSelectCanEdit"]);
            Assert.AreEqual(false, _booleanAttributesCreated["I"]["CanEdit"]);
            Assert.AreEqual(false, _booleanAttributesCreated["I"]["rowidCanEdit"]);
        }

        [TestMethod]
        public void AddDetailRow_TotResResColumn_AddsAttribute()
        {
            // Arrange
            var column = _columns[0];
            column.m_id = RPConstants.TGRID_TOTRESRES_ID;
            _columns = new[] { column };
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            Assert.IsTrue(_stringAttributesCreated["I"].ContainsKey("ResOrRole"));
        }

        [TestMethod]
        public void AddDetailRow_TotDeptColumnUseRole_AddsAttribute()
        {
            // Arrange
            var column = _columns[0];
            column.m_id = RPConstants.TGRID_TOTDEPT_ID;
            _columns = new[] { column };
            _useRole = false;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            var sn = column.m_realname
                   .Replace(" ", string.Empty)
                   .Replace("/n", string.Empty)
                   .Replace("\r", string.Empty)
                   .Replace("\n", string.Empty);

            Assert.IsFalse(_stringAttributesCreated["I"].ContainsKey(sn));
        }

        [TestMethod]
        public void AddDetailRow_TotDeptColumnNotUseRole_AddsAttribute()
        {
            // Arrange
            var column = _columns[0];
            column.m_id = RPConstants.TGRID_TOTDEPT_ID;
            _columns = new[] { column };
            const string testName = "test-name";
            _detailRow.resavail = new clsResxAvail { DeptID = 15 };
            _resourceValues.Departments = new Dictionary<int, clsEPKItem>
            {
                [_detailRow.resavail.DeptID] = new clsEPKItem { Name = testName }
            };
            _useRole = false;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            var sn = column.m_realname
                   .Replace(" ", string.Empty)
                   .Replace("/n", string.Empty)
                   .Replace("\r", string.Empty)
                   .Replace("\n", string.Empty);

            Assert.IsTrue(_stringAttributesCreated["I"].ContainsKey(sn));
            Assert.AreEqual(testName, _stringAttributesCreated["I"][sn]);
        }

        [TestMethod]
        public void AddDetailRow_TotItemColumn_AddsAttribute()
        {
            // Arrange
            var column = _columns[0];
            column.m_id = RPConstants.TGRID_TOTITEM_ID;
            _columns = new[] { column };
            const string test1 = "test-1";
            const string test2 = "test-2";
            _detailRow.PIList = new Dictionary<int, string>
            {
                [1] = test1,
                [2] = test2,
            };
            _useRole = false;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            var sn = column.m_realname
                   .Replace(" ", string.Empty)
                   .Replace("/n", string.Empty)
                   .Replace("\r", string.Empty)
                   .Replace("\n", string.Empty);

            Assert.IsTrue(_stringAttributesCreated["I"].ContainsKey(sn));
            Assert.AreEqual($"{test1},{test2}", _stringAttributesCreated["I"][sn]);
        }

        [TestMethod]
        public void AddDetailRow_TotRoleColumnUseRole_AddsAttribute()
        {
            // Arrange
            var column = _columns[0];
            column.m_id = RPConstants.TGRID_TOTROLE_ID;
            _columns = new[] { column };
            _useRole = false;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            var sn = column.m_realname
                   .Replace(" ", string.Empty)
                   .Replace("/n", string.Empty)
                   .Replace("\r", string.Empty)
                   .Replace("\n", string.Empty);

            Assert.IsFalse(_stringAttributesCreated["I"].ContainsKey(sn));
        }

        [TestMethod]
        public void AddDetailRow_TotRoleColumnNotUseRole_AddsAttribute()
        {
            // Arrange
            var column = _columns[0];
            column.m_id = RPConstants.TGRID_TOTROLE_ID;
            _columns = new[] { column };
            const string testName = "test-name";
            _detailRow.resavail = new clsResxAvail { RoleID = 15 };
            _resourceValues.Roles = new Dictionary<int, clsListItem>
            {
                [_detailRow.resavail.RoleID] = new clsListItem { Name = testName }
            };
            _useRole = false;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            var sn = column.m_realname
                   .Replace(" ", string.Empty)
                   .Replace("/n", string.Empty)
                   .Replace("\r", string.Empty)
                   .Replace("\n", string.Empty);

            Assert.IsTrue(_stringAttributesCreated["I"].ContainsKey(sn));
            Assert.AreEqual(testName, _stringAttributesCreated["I"][sn]);
        }

        [TestMethod]
        public void AddDetailRow_TotCostColumnUseRole_AddsAttribute()
        {
            // Arrange
            var column = _columns[0];
            column.m_id = RPConstants.TGRID_TOTCC_ID;
            _columns = new[] { column };
            _useRole = false;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            var sn = column.m_realname
                   .Replace(" ", string.Empty)
                   .Replace("/n", string.Empty)
                   .Replace("\r", string.Empty)
                   .Replace("\n", string.Empty);

            Assert.IsFalse(_stringAttributesCreated["I"].ContainsKey(sn));
        }

        [TestMethod]
        public void AddDetailRow_TotCostColumnNotUseRole_AddsAttribute()
        {
            // Arrange
            var column = _columns[0];
            column.m_id = RPConstants.TGRID_TOTCC_ID;
            _columns = new[] { column };
            const string testName = "test-name";
            _detailRow.resavail = new clsResxAvail { CostCat = 15 };
            _resourceValues.CostCategories = new Dictionary<int, clsCatItem>
            {
                [_detailRow.resavail.CostCat] = new clsCatItem { Name = testName }
            };
            _useRole = false;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            var sn = column.m_realname
                   .Replace(" ", string.Empty)
                   .Replace("/n", string.Empty)
                   .Replace("\r", string.Empty)
                   .Replace("\n", string.Empty);

            Assert.IsTrue(_stringAttributesCreated["I"].ContainsKey(sn));
            Assert.AreEqual(testName, _stringAttributesCreated["I"][sn]);
        }

        [TestMethod]
        public void AddDetailRow_TotCostFullColumnUseRole_AddsAttribute()
        {
            // Arrange
            var column = _columns[0];
            column.m_id = RPConstants.TGRID_TOTCCFULL_ID;
            _columns = new[] { column };
            _useRole = false;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            var sn = column.m_realname
                   .Replace(" ", string.Empty)
                   .Replace("/n", string.Empty)
                   .Replace("\r", string.Empty)
                   .Replace("\n", string.Empty);

            Assert.IsFalse(_stringAttributesCreated["I"].ContainsKey(sn));
        }

        [TestMethod]
        public void AddDetailRow_TotCostFullColumnNotUseRole_AddsAttribute()
        {
            // Arrange
            var column = _columns[0];
            column.m_id = RPConstants.TGRID_TOTCCFULL_ID;
            _columns = new[] { column };
            const string testName = "test-name";
            _detailRow.resavail = new clsResxAvail { CostCat = 15 };
            _resourceValues.CostCategories = new Dictionary<int, clsCatItem>
            {
                [_detailRow.resavail.CostCat] = new clsCatItem { FullName = testName }
            };
            _useRole = false;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            var sn = column.m_realname
                   .Replace(" ", string.Empty)
                   .Replace("/n", string.Empty)
                   .Replace("\r", string.Empty)
                   .Replace("\n", string.Empty);

            Assert.IsTrue(_stringAttributesCreated["I"].ContainsKey(sn));
            Assert.AreEqual(testName, _stringAttributesCreated["I"][sn]);
        }

        [TestMethod]
        public void AddDetailRow_PeriodsProvidedValueNotEmpty_SetsCellValueAttribute()
        {
            // Arrange, Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            foreach (var period in _periods)
            {
                for (var i = 1; i <= _displayList.Count; i++)
                {
                    var prefix = "P" + period.PeriodID + "C" + i;
                    Assert.AreEqual(1d.ToString("0.##"), _stringAttributesCreated["I"][prefix]);
                }
            }
        }
    }
}
