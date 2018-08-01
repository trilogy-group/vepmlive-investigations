using System;
using System.Collections.Generic;
using CADataCache;
using CostDataValues;
using Global.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.Tests.TestDoubles.CADataCache;

namespace WorkEnginePPM.Tests.WebServices.CADataCache
{
    [TestClass]
    public class CATopGridTest
    {
        private const int _arraySize = 64;

        private IDisposable _shimsContext;

        private int _rowId;
        private bool _hideRowsWithAllZeros;
        private bool _showFTEs;
        private bool _useQuantity;
        private bool _useCost;
        private bool _showCostDetailed;
        private int _pmoAdmin;
        private IList<clsColDisp> _columns;
        private IList<CATGRow> _displayList;
        private GridRenderingTypes _renderingType;
        private CATopGridTestDouble _testDouble;

        private ICollection<string> _substructsCreated;
        private IDictionary<string, IDictionary<string, string>> _stringAttributesCreated;
        private IDictionary<string, IDictionary<string, bool>> _booleanAttributesCreated;
        private IDictionary<string, IDictionary<string, int>> _intAttributesCreated;
        private IDictionary<string, IDictionary<string, double>> _doubleAttributesCreated;

        private IList<clsPeriodData> _periods;
        private clsDetailRowData _detailRow;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            _hideRowsWithAllZeros = false;
            _showFTEs = false;
            _useQuantity = false;
            _useCost = false;
            _showCostDetailed = false;
            _pmoAdmin = 0;

            _renderingType = GridRenderingTypes.Combined;

            _columns = new[]
            {
                new clsColDisp { m_id = (int)FieldIDs.FTOT_FID, m_realname="test!@#$%^&*()_+-={}[]|:;'?/~` '\r\n\"\\", m_dispname = "test-display" },
                new clsColDisp { m_id = (int)FieldIDs.PI_FID, m_realname="test!@#$%^&*()_+-={}[]|:;'?/~` '\r\n\"\\", m_dispname = "test-display" }
            };
            _displayList = new[]
            {
                new CATGRow { bUse = true }
            };
            _periods = new[] {
                new clsPeriodData
                {
                    PeriodID = 1,
                    PeriodName = "test-1"
                },
                new clsPeriodData
                {
                    PeriodID = 2,
                    PeriodName = "test-2"
                }
            };

            _pmoAdmin = 0;
            _detailRow = new clsDetailRowData(_arraySize)
            {
                PI_Name = "test-name",
                m_tot1 = 99
            };

            _rowId = 3;

            _testDouble = CreateTestDouble();

            _substructsCreated = new HashSet<string>();
            _stringAttributesCreated = new Dictionary<string, IDictionary<string, string>>();
            _booleanAttributesCreated = new Dictionary<string, IDictionary<string, bool>>();
            _intAttributesCreated = new Dictionary<string, IDictionary<string, int>>();
            _doubleAttributesCreated = new Dictionary<string, IDictionary<string, double>>();

            SetUpShims();
        }

        private void SetUpShims()
        {
            ShimCStruct.AllInstances.CreateSubStructString = (instance, subStructName) =>
            {
                _substructsCreated.Add(subStructName);

                return new ShimCStruct
                {
                    NameGet = () => subStructName
                };
            };

            ShimCStruct.AllInstances.CreateStringAttrStringString = (element, name, value) =>
            {
                if (!_stringAttributesCreated.ContainsKey(element.Name))
                {
                    _stringAttributesCreated[element.Name] = new Dictionary<string, string>();
                }

                _stringAttributesCreated[element.Name][name] = value;
            };
            ShimCStruct.AllInstances.CreateBooleanAttrStringBoolean = (element, name, value) =>
            {
                if (!_booleanAttributesCreated.ContainsKey(element.Name))
                {
                    _booleanAttributesCreated[element.Name] = new Dictionary<string, bool>();
                }

                _booleanAttributesCreated[element.Name][name] = value;
            };
            ShimCStruct.AllInstances.CreateIntAttrStringInt32 = (element, name, value) =>
            {
                if (!_intAttributesCreated.ContainsKey(element.Name))
                {
                    _intAttributesCreated[element.Name] = new Dictionary<string, int>();
                }

                _intAttributesCreated[element.Name][name] = value;
            };
            ShimCStruct.AllInstances.CreateDoubleAttrStringDouble = (element, name, value) =>
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

        private CATopGridTestDouble CreateTestDouble()
        {
            return new CATopGridTestDouble(
                _hideRowsWithAllZeros,
                _showFTEs,
                _useQuantity,
                _useCost,
                _showCostDetailed,
                _pmoAdmin,
                _displayList,
                _columns
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
            Assert.AreEqual("zXPortfolioItem", _stringAttributesCreated["Cfg"]["MainCol"]);
            Assert.AreEqual("GTACCNPSQEBSLC", _stringAttributesCreated["Cfg"]["Code"]);
            Assert.AreEqual(3, _intAttributesCreated["Cfg"]["SuppressCfg"]);
            Assert.AreEqual(3, _intAttributesCreated["Cfg"]["SuppressMessage"]);
            Assert.AreEqual(_pmoAdmin, _intAttributesCreated["Cfg"]["Dragging"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["Sorting"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["ColsMoving"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["ColsPosLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["ColsLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["VisibleLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["SectionWidthLap"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["GroupLap"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["WideHScroll"]);
            Assert.AreEqual(150, _intAttributesCreated["Cfg"]["LeftWidth"]);
            Assert.AreEqual(400, _intAttributesCreated["Cfg"]["Width"]);
            Assert.AreEqual(800, _intAttributesCreated["Cfg"]["RightWidth"]);
            Assert.AreEqual(50, _intAttributesCreated["Cfg"]["MinMidWidth"]);
            Assert.AreEqual(400, _intAttributesCreated["Cfg"]["MinRightWidth"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["LeftCanResize"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["RightCanResize"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["FocusWholeRow"]);
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
        public void InitializeGridLayout_Always_InitializesLayoutConfigCfgWidths()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Cfg"));
            Assert.AreEqual(150, _intAttributesCreated["Cfg"]["LeftWidth"]);
            Assert.AreEqual(400, _intAttributesCreated["Cfg"]["Width"]);
            Assert.AreEqual(800, _intAttributesCreated["Cfg"]["RightWidth"]);
            Assert.AreEqual(50, _intAttributesCreated["Cfg"]["MinMidWidth"]);
            Assert.AreEqual(400, _intAttributesCreated["Cfg"]["MinRightWidth"]);
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
            Assert.AreEqual("Cols", _testDouble.MiddleCols.Name);
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesDefinitions()
        {
            // Arrange
            var definitionsInitialized = new List<string>();
            ShimGridBase<clsPeriodData, clsDetailRowData>.AllInstances.InitializeGridLayoutDefinitionStringCStruct = (instance, name, definitions) =>
            {
                definitionsInitialized.Add(name);
                return new PortfolioEngineCore.CStruct();
            };

            // Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            Assert.AreEqual(2, definitionsInitialized.Count);
            Assert.IsTrue(definitionsInitialized.Contains("R"));
            Assert.IsTrue(definitionsInitialized.Contains("Leaf"));
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
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesCategoryColumns()
        {
            // Arrange
            var nameAttributeValues = new HashSet<string>();
            var typeAttributeValues = new HashSet<string>();
            ShimCStruct.AllInstances.CreateStringAttrStringString = (element, name, value) =>
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
        }

        [TestMethod]
        public void InitializeGridLayout_Always_InitializesViewColumns()
        {
            // Arrange, Act
            _testDouble.InitializeGridLayout(_renderingType);

            // Assert
            foreach (var column in _columns)
            {
                Assert.IsTrue(_stringAttributesCreated["Header"].ContainsKey("zX" + _testDouble.CleanUpString(column.m_realname)));
            }
        }

        [TestMethod]
        public void ResolvePeriodId_Always_ReturnsPeriodId()
        {
            // Arrange
            var periodData = new clsPeriodData
            {
                PeriodID = 2
            };

            // Act
            var result = _testDouble.ResolvePeriodId(periodData, 10);

            // Assert
            Assert.AreEqual(periodData.PeriodID.ToString(), result);
        }

        [TestMethod]
        public void AddPeriodColumns_DisplayRowsInUse_Header1AttributesSet()
        {
            // Arrange, Act
            _testDouble.AddPeriodColumns(_periods);

            // Assert
            Assert.AreEqual(_periods.Count, _stringAttributesCreated["Header1"].Count);

            foreach (var period in _periods)
            {
                Assert.IsTrue(_stringAttributesCreated["Header1"].ContainsKey("P" + period.PeriodID + "C" + _displayList.Count));
            }
        }

        [TestMethod]
        public void AddPeriodColumns_DisplayRowsInUse_Header2AttributesNotSet()
        {
            // Arrange, Act
            _testDouble.AddPeriodColumns(_periods);

            // Assert
            Assert.IsFalse(_stringAttributesCreated.ContainsKey("Header2"));
        }

        [TestMethod]
        public void AddPeriodColumns_DisplayRowsInUseUseCost_Header2AttributesSetToCost()
        {
            // Arrange
            _useCost = true;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddPeriodColumns(_periods);

            // Assert
            Assert.AreEqual(_periods.Count, _stringAttributesCreated["Header2"].Count);

            foreach (var period in _periods)
            {
                Assert.AreEqual("Cost", _stringAttributesCreated["Header2"]["P" + period.PeriodID + "C" + 1]);
            }
        }

        [TestMethod]
        public void AddPeriodColumns_DisplayRowsInUseUseQuantity_Header2AttributesSetToQty()
        {
            // Arrange
            _useQuantity = true;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddPeriodColumns(_periods);

            // Assert
            Assert.AreEqual(_periods.Count, _stringAttributesCreated["Header2"].Count);

            foreach (var period in _periods)
            {
                Assert.AreEqual("Qty", _stringAttributesCreated["Header2"]["P" + period.PeriodID + "C" + 1]);
            }
        }

        [TestMethod]
        public void AddPeriodColumns_DisplayRowsInUseUseQuantity_Header2AttributesSetToFTE()
        {
            // Arrange
            _showFTEs = true;
            _testDouble = CreateTestDouble();

            // Act
            _testDouble.AddPeriodColumns(_periods);

            // Assert
            Assert.AreEqual(_periods.Count, _stringAttributesCreated["Header2"].Count);

            foreach (var period in _periods)
            {
                Assert.AreEqual("FTE", _stringAttributesCreated["Header2"]["P" + period.PeriodID + "C" + 1]);
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
            clsDetailRowData detailRow = null;

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
            Assert.AreEqual(1, _intAttributesCreated["I"]["NoColorState"]);
            Assert.AreEqual(false, _booleanAttributesCreated["I"]["CanEdit"]);
            Assert.AreEqual(true, _booleanAttributesCreated["I"]["SelectCanEdit"]);
            Assert.AreEqual(_detailRow.bSelected ? "1" : "0", _stringAttributesCreated["I"]["Select"]);
        }

        [TestMethod]
        public void AddDetailRow_ExpectedColumnsProvided_AddsAttributesForEachColumn()
        {
            // Arrange, Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            foreach(var column in _columns)
            { 
                Assert.IsTrue(_stringAttributesCreated["I"].ContainsKey("zX" + _testDouble.CleanUpString(column.m_realname)));
            }
        }

        [TestMethod]
        public void AddDetailRow_PeriodsEmpty_PeriodsAttributesSetUp()
        {
            // Arrange, Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            Assert.AreEqual(_arraySize + 1, _intAttributesCreated["I"]["xinterenalPeriodMin"]);
            Assert.AreEqual(0, _intAttributesCreated["I"]["xinterenalPeriodMax"]);
            Assert.AreEqual(_arraySize, _intAttributesCreated["I"]["xinterenalPeriodTotal"]);
        }

        [TestMethod]
        public void AddDetailRow_PeriodsCanBeCalculated_PeriodsAttributesSetUp()
        {
            // Arrange
            var minPeriod = 3;
            var maxPeriod = 21;

            _useQuantity = true;
            _testDouble = CreateTestDouble();

            foreach (var displayRow in _displayList)
            {
                displayRow.bUse = true;
            }
            _detailRow.zValue[minPeriod] = 1;
            _detailRow.zValue[maxPeriod] = 1;

            // Act
            _testDouble.AddDetailRow(_detailRow, _rowId);

            // Assert
            Assert.AreEqual(minPeriod, _intAttributesCreated["I"]["xinterenalPeriodMin"]);
            Assert.AreEqual(maxPeriod, _intAttributesCreated["I"]["xinterenalPeriodMax"]);
            Assert.AreEqual(_arraySize, _intAttributesCreated["I"]["xinterenalPeriodTotal"]);
        }
    }
}
