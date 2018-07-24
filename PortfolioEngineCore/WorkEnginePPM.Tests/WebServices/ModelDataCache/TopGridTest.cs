using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using ModelDataCache.Fakes;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.Tests.TestDoubles;

namespace WorkEnginePPM.Tests.WebServices.ModelDataCache
{
    [TestClass]
    public class TopGridTest
    {
        private IDisposable _shimsContext;

        private ICollection<string> _substructsCreated = new HashSet<string>();
        private IDictionary<string, IDictionary<string, string>> _stringAttributesCreated;
        private IDictionary<string, IDictionary<string, bool>> _booleanAttributesCreated;
        private IDictionary<string, IDictionary<string, int>> _intAttributesCreated;
        private IDictionary<string, IDictionary<string, double>> _doubleAttributesCreated;

        private bool _useGroupingParameter;
        private bool _showFTEsParameter;
        private bool _showGanttParameter;
        private DateTime _dateStartParameter;
        private DateTime _dateEndParameter;
        private IList<SortFieldDefn> _sortFieldsParameter;
        private int _detFreezeParameter;

        private string _idParameter;
        private string _nameParameter;
        private bool _useQuantityParameter;
        private bool _useCostParameter;
        private bool _showCostDetailedParameter;
        private int _fromPeriodIndexParameter;
        private int _toPeriodIndexParameter;

        private DetailRowData _detailRowParameter;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();
            
            _useGroupingParameter = false;
            _showFTEsParameter = false;
            _showGanttParameter = false;
            _dateStartParameter = DateTime.MinValue;
            _dateEndParameter = DateTime.MaxValue;
            _sortFieldsParameter = new SortFieldDefn[] { };
            _detFreezeParameter = 0;

            _idParameter = "test-id";
            _nameParameter = "test-name";
            _useQuantityParameter = false;
            _useCostParameter = false;
            _showCostDetailedParameter = false;
            _fromPeriodIndexParameter = 0;
            _toPeriodIndexParameter = 10;

            _substructsCreated = new HashSet<string>();
            _stringAttributesCreated = new Dictionary<string, IDictionary<string, string>>();
            _booleanAttributesCreated = new Dictionary<string, IDictionary<string, bool>>();
            _intAttributesCreated = new Dictionary<string, IDictionary<string, int>>();
            _doubleAttributesCreated = new Dictionary<string, IDictionary<string, double>>();

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
            
            _detailRowParameter = new DetailRowData(64)
            {
                m_lev = 1,
                bSelected = true,
                bRealone = true,
                bGotChildren = true
            };
        }

        private TopGridTestDouble CreateGridBase()
        {
            return new TopGridTestDouble(
                _useGroupingParameter,
                _showFTEsParameter,
                _showGanttParameter,
                _dateStartParameter,
                _dateEndParameter,
                _sortFieldsParameter,
                _detFreezeParameter,
                _useQuantityParameter,
                _useCostParameter,
                _showCostDetailedParameter,
                _fromPeriodIndexParameter,
                _toPeriodIndexParameter
            );
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void CleanUpString_InputNull_Throws()
        {
            // Arrange
            const string input = null;
            var gridBase = CreateGridBase();

            try
            {
                // Act
                gridBase.CleanUpString(input);
            }
            // Assert
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void CleanUpString_InputHasNastyCharacters_Removes()
        {
            // Arrange
            const string input = "valid" + "!@#$%^&*()_+-={}[]|:;'?/~` '\r\n\"\\";
            var gridBase = CreateGridBase();

            // Act
            var result = gridBase.CleanUpString(input);

            // Assert
            Assert.AreEqual("valid", result);
        }

        [TestMethod]
        public void AddDetailRow_Always_AddsExpectedAttributes()
        {
            // Arrange
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(_detailRowParameter);

            // Assert
            Assert.AreEqual("0", _stringAttributesCreated["I"]["id"]);
            Assert.AreEqual("1", _stringAttributesCreated["I"]["Select"]);
            Assert.AreEqual(true, _booleanAttributesCreated["I"]["SelectCanEdit"]);
            Assert.AreEqual(false, _booleanAttributesCreated["I"]["CanEdit"]);
            Assert.AreEqual(1, _intAttributesCreated["I"]["NoColorState"]);
        }

        [TestMethod]
        public void AddDetailRow_Realone_AddsColor()
        {
            // Arrange
            _detailRowParameter.bRealone = true;
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(_detailRowParameter);

            // Assert
            Assert.AreEqual("255,255,255", _stringAttributesCreated["I"]["Color"]);
        }

        [TestMethod]
        public void AddDetailRow_LevelNotEqualTo1_AddsCanFilterAttribute()
        {
            // Arrange
            _detailRowParameter.m_lev = 2;
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(_detailRowParameter);

            // Assert
            Assert.AreEqual(2, _intAttributesCreated["I"]["CanFilter"]);
        }

        [TestMethod]
        public void AddDetailRow_UseGroupping_AddsSpecificAttributes()
        {
            // Arrange
            _useGroupingParameter = true;
            _detailRowParameter.sName = "test-name";
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(_detailRowParameter);

            // Assert
            Assert.AreEqual(_detailRowParameter.sName, _stringAttributesCreated["I"]["xGrouping"]);
        }

        [TestMethod]
        public void AddDetailRow_ShowGanttAndNoChildren_AddsSpecificAttributes()
        {
            // Arrange
            _showGanttParameter = true;
            _detailRowParameter.bGotChildren = false;

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(_detailRowParameter);

            // Assert
            Assert.AreEqual("GanttBlue", _stringAttributesCreated["I"]["GGanttClass"]);
        }

        [TestMethod]
        public void AddDetailRow_NoGanttUseCostNoRounding_CreatesAttributesForMinToMaxP()
        {
            // Arrange
            _showGanttParameter = false;
            _useCostParameter = true;
            _showCostDetailedParameter = true;

            for (var i = _fromPeriodIndexParameter; i <= _toPeriodIndexParameter; i++)
            {
                _detailRowParameter.zCost[i] = 1.1 * i;
            }

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(_detailRowParameter);

            // Assert
            for (var i = _fromPeriodIndexParameter; i <= _fromPeriodIndexParameter; i++)
            {
                Assert.AreEqual(_detailRowParameter.zCost[i], _doubleAttributesCreated["I"]["P" + i + "C"]);
            }
        }

        [TestMethod]
        public void AddDetailRow_NoGanttUseCostWithRounding_CreatesAttributesForMinToMaxP()
        {
            // Arrange
            _showGanttParameter = false;
            _useCostParameter = true;
            _showCostDetailedParameter = false;

            for (var i = _fromPeriodIndexParameter; i <= _toPeriodIndexParameter; i++)
            {
                _detailRowParameter.zCost[i] = 1.1 * i;
            }

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(_detailRowParameter);

            // Assert
            for (var i = _fromPeriodIndexParameter; i <= _toPeriodIndexParameter; i++)
            {
                Assert.AreEqual((double)(int)_detailRowParameter.zCost[i], _doubleAttributesCreated["I"]["P" + i + "C"]);
            }
        }

        [TestMethod]
        public void InitializeGridLayout_InvalidRenderingType_Throws()
        {
            // Arrange
            _detailRowParameter.bRealone = true;
            var grid = CreateGridBase();

            // Act
            Action action = () => grid.InitializeGridLayout(GridRenderingTypes.None);

            // Assert
            try
            {
                action();
            }
            catch (ArgumentException)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void InitializeGridLayout_ValidRenderingType_GeneratesOtherAttributesRequired()
        {
            // Arrange
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridLayout(GridRenderingTypes.Combined);

            // Assert
            Assert.AreEqual(0, _intAttributesCreated["Toolbar"]["Visible"]);
            Assert.AreEqual(1, _intAttributesCreated["Panel"]["Visible"]);
        }

        [TestMethod]
        public void InitializeGridLayout_ValidRenderingType_GeneratesCfgAttributesRequired()
        {
            // Arrange
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridLayout(GridRenderingTypes.Combined);

            // Assert
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["MaxHeight"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["ShowDeleted"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["Deleting"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["Selecting"]);
            Assert.AreEqual(3, _intAttributesCreated["Cfg"]["SuppressCfg"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["PrintCols"]);
            Assert.AreEqual(true, _booleanAttributesCreated["Cfg"]["DateStrings"]);
            Assert.AreEqual(true, _booleanAttributesCreated["Cfg"]["NoTreeLines"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["MaxWidth"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["AppendId"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["FullId"]);
            Assert.AreEqual("0123456789", _stringAttributesCreated["Cfg"]["IdChars"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["NumberId"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["Dragging"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["DragEdit"]);
            Assert.AreEqual(400, _intAttributesCreated["Cfg"]["LeftWidth"]);
            Assert.AreEqual("R", _stringAttributesCreated["Cfg"]["IdPrefix"]);
            Assert.AreEqual("x", _stringAttributesCreated["Cfg"]["IdPostfix"]);
            Assert.AreEqual(0, _intAttributesCreated["Cfg"]["CaseSensitiveId"]);
            Assert.AreEqual("GTACCNPSQEBSLC", _stringAttributesCreated["Cfg"]["Code"]);
            Assert.AreEqual("GM", _stringAttributesCreated["Cfg"]["Style"]);
            Assert.AreEqual("Modeler", _stringAttributesCreated["Cfg"]["CSS"]);
            Assert.AreEqual(800, _intAttributesCreated["Cfg"]["RightWidth"]);
            Assert.AreEqual(200, _intAttributesCreated["Cfg"]["MinMidWidth"]);
            Assert.AreEqual(400, _intAttributesCreated["Cfg"]["MinRightWidth"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["LeftCanResize"]);
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["RightCanResize"]);
        }

        [TestMethod]
        public void InitializeGridLayout_ValidRenderingType_GeneratesMDefTreeAttributesRequired()
        {
            // Arrange
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridLayout(GridRenderingTypes.Combined);

            // Assert
            Assert.AreEqual("R", _stringAttributesCreated["D"]["Name"]);
            Assert.AreEqual("Color", _stringAttributesCreated["D"]["HoverCell"]);
            Assert.AreEqual("Color", _stringAttributesCreated["D"]["HoverRow"]);
            Assert.AreEqual("", _stringAttributesCreated["D"]["FocusCell"]);
            Assert.AreEqual("ClearSelection+Grid.SelectRow(Row,!Row.Selected)", _stringAttributesCreated["D"]["OnFocus"]);
            Assert.AreEqual(1, _intAttributesCreated["D"]["NoColorState"]);
        }
        
        [TestMethod]
        public void InitializeGridData_DataRenderingType_CreatesCfg()
        {
            // Arrange
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridData(GridRenderingTypes.Data);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Cfg"));
        }


        [TestMethod]
        public void InitializeGridData_InvalidRenderingType_Throws()
        {
            // Arrange
            const GridRenderingTypes renderingType = GridRenderingTypes.None;
            var grid = CreateGridBase();

            // Act
            Action action = () => grid.InitializeGridData(renderingType);

            // Assert
            try
            {
                action();
            }
            catch (ArgumentException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void InitializeGridData_Always_ExpectedStructure()
        {
            // Arrange
            const GridRenderingTypes renderingType = GridRenderingTypes.Data;
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridData(renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Body"));
            Assert.IsTrue(_substructsCreated.Contains("B"));
            Assert.IsTrue(_substructsCreated.Contains("I"));
            Assert.AreEqual(false, _booleanAttributesCreated["I"]["CanEdit"]);
        }

        [TestMethod]
        public void InitializeGridData_Always_LevelSet()
        {
            // Arrange
            const GridRenderingTypes renderingType = GridRenderingTypes.Data;
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridData(renderingType);

            // Assert
            Assert.AreEqual(0, grid.Level);
            Assert.AreEqual("I", grid.Levels[0].Name);
        }

        [TestMethod]
        public void InitializeGridData_RenderingTypeData_ExpectedStructure()
        {
            // Arrange
            const GridRenderingTypes renderingType = GridRenderingTypes.Data;
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridData(renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Cfg"));
            Assert.AreEqual(1, _intAttributesCreated["Cfg"]["FilterEmpty"]);
        }

        [TestMethod]
        public void InitializeGridLayout_ShowGantt_CategoryColumnInitialized()
        {
            // Arrange
            const GridRenderingTypes renderingType = GridRenderingTypes.Data;
            _showGanttParameter = true;
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridLayout(renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("C"));
            Assert.AreEqual("G", _stringAttributesCreated["C"]["Name"]);
            Assert.AreEqual("Gantt", _stringAttributesCreated["C"]["Type"]);
            Assert.AreEqual("Main", _stringAttributesCreated["C"]["GanttObject"]);
            Assert.AreEqual("0", _stringAttributesCreated["C"]["CanExport"]);
            Assert.AreEqual(1, _intAttributesCreated["C"]["GanttLap"]);
            Assert.AreEqual("Start", _stringAttributesCreated["C"]["GanttStart"]);
            Assert.AreEqual("Finish", _stringAttributesCreated["C"]["GanttEnd"]);
            Assert.AreEqual("d", _stringAttributesCreated["C"]["GanttUnits"]);
            Assert.AreEqual("w", _stringAttributesCreated["C"]["GanttChartRound"]);
            Assert.AreEqual("1", _stringAttributesCreated["C"]["GanttRight"]);
            Assert.AreEqual("Slack", _stringAttributesCreated["C"]["GanttSlack"]);
            Assert.AreEqual("y#yy", _stringAttributesCreated["C"]["GanttHeader1"]);
            Assert.AreEqual("M#MMM", _stringAttributesCreated["C"]["GanttHeader2"]);
            Assert.AreEqual(grid.DateStart.ToString("MM/dd/yyyy"), _stringAttributesCreated["C"]["GanttChartMinStart"]);
            Assert.AreEqual(grid.DateEnd.ToString("MM/dd/yyyy"), _stringAttributesCreated["C"]["GanttChartMinEnd"]);
            Assert.AreEqual(grid.DateStart.ToString("MM/dd/yyyy"), _stringAttributesCreated["C"]["GanttChartMaxStart"]);
            Assert.AreEqual(grid.DateEnd.ToString("MM/dd/yyyy"), _stringAttributesCreated["C"]["GanttChartMaxEnd"]);
            Assert.AreEqual(" ", _stringAttributesCreated["Header"]["G"]);
        }

        [TestMethod]
        public void InitializeGridLayout_ShowGantt_ZoomInitialized()
        {
            // Arrange
            const GridRenderingTypes renderingType = GridRenderingTypes.Data;
            _showGanttParameter = true;
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridLayout(renderingType);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Zoom"));
            Assert.IsTrue(_substructsCreated.Contains("Z"));
            Assert.AreEqual("Zoom6", _stringAttributesCreated["Z"]["Name"]);
            Assert.AreEqual("d", _stringAttributesCreated["Z"]["GanttUnits"]);
            Assert.AreEqual("20", _stringAttributesCreated["Z"]["GanttWidth"]);
            Assert.AreEqual("M", _stringAttributesCreated["Z"]["GanttChartRound"]);
            Assert.AreEqual("M#MM yyyy", _stringAttributesCreated["Z"]["GanttHeader1"]);
            Assert.AreEqual("d#dd", _stringAttributesCreated["Z"]["GanttHeader2"]);
        }

        [TestMethod]
        public void ResolvePeriodId_Always_ReturnsPeriodDataId()
        {
            // Arrange
            var periodData = new PeriodData { PeriodID = 18 };
            const int index = 5;
            var grid = CreateGridBase();

            // Act
            var result = grid.ResolvePeriodId(periodData, index);

            // Assert
            Assert.AreEqual(index.ToString(), result);
        }
    }
}
