using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Global.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using ModelDataCache.Fakes;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.Tests.TestDoubles;

namespace WorkEnginePPM.Tests.WebServices.ModelDataCache
{
    [TestClass]
    public class BottomGridTest
    {
        private IDisposable _shimsContext;

        private ICollection<string> _substructsCreated;
        private IDictionary<string, IDictionary<string, string>> _stringAttributesCreated;
        private IDictionary<string, IDictionary<string, bool>> _booleanAttributesCreated;
        private IDictionary<string, IDictionary<string, int>> _intAttributesCreated;
        private IDictionary<string, IDictionary<string, double>> _doubleAttributesCreated;

        private bool _applyTargetParameter;
        private IList<DetailRowData> _targetsSortedParameter;
        private IList<TargetColours> _targetColorsParameter;
        private bool _showRemainingParameter;

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

            _applyTargetParameter = false;
            _targetsSortedParameter = new List<DetailRowData>();
            _targetColorsParameter = new List<TargetColours>();

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

        private BottomGridTestDouble CreateGridBase()
        {
            return new BottomGridTestDouble(
                _applyTargetParameter,
                _targetsSortedParameter,
                _targetColorsParameter,
                _showRemainingParameter,
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
        public void AddDetailRow_Always_AddsExpectedAttributes()
        {
            // Arrange
            const int idExpected = 12;
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(_detailRowParameter, idExpected);

            // Assert
            Assert.AreEqual(idExpected.ToString(), _stringAttributesCreated["I"]["id"]);
            Assert.AreEqual("255,255,255", _stringAttributesCreated["I"]["Color"]);
            Assert.AreEqual(false, _booleanAttributesCreated["I"]["CanEdit"]);
        }

        [TestMethod]
        public void AddDetailRow_UseGrouping_AddsGroupingAttribute()
        {
            // Arrange
            _useGroupingParameter = true;
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(_detailRowParameter);

            // Assert
            Assert.AreEqual(_detailRowParameter.sName, _stringAttributesCreated["I"]["Grouping"]);
        }

        [TestMethod]
        public void AddDetailRow_HasSortFields_TriesToGetDataFromAllSortFields()
        {
            // Arrange
            _useGroupingParameter = true;
            _sortFieldsParameter = new[] {
                new SortFieldDefn { fid = 1, name = "1" },
                new SortFieldDefn { fid = 2, name = "2" },
                new SortFieldDefn { fid = 4, name = "4" },
            };
            var gridBase = CreateGridBase();
            var fieldIdsUsed = new HashSet<int>();
            
            ShimGridBase.AllInstances.TryGetDataFromDetailRowDataFieldDetailRowDataInt32StringOut = (GridBase grid, DetailRowData detailRow, int fieldId, out string value) =>
            {
                value = null;
                fieldIdsUsed.Add(fieldId);
                return true;
            };

            // Act
            gridBase.AddDetailRow(_detailRowParameter);

            // Assert
            Assert.AreEqual(_sortFieldsParameter.Count, fieldIdsUsed.Count);
            Assert.IsTrue(_sortFieldsParameter.All(pred => fieldIdsUsed.Contains(pred.fid)));
        }

        [TestMethod]
        public void AddDetailRow_Realone_AddsColor()
        {
            // Arrange
            _useQuantityParameter = true;
            _detailRowParameter.bRealone = true;
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(_detailRowParameter, 0);

            // Assert
            Assert.AreEqual("255,255,255", _stringAttributesCreated["I"]["Color"]);
        }

        [TestMethod]
        public void InitializeGridLayout_InvalidRenderingType_Throws()
        {
            // Arrange
            _detailRowParameter.bRealone = true;
            var grid = CreateGridBase();

            // Act
            Action action = () => grid.InitializeGridLayout(GridBase.RenderingTypes.None);

            // Assert
            try
            {
                action();
            }
            catch(ArgumentException)
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
            grid.InitializeGridLayout(GridBase.RenderingTypes.Combined);

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
            grid.InitializeGridLayout(GridBase.RenderingTypes.Combined);

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
            grid.InitializeGridLayout(GridBase.RenderingTypes.Combined);

            // Assert
            Assert.AreEqual("R", _stringAttributesCreated["D"]["Name"]);
            Assert.AreEqual("Color", _stringAttributesCreated["D"]["HoverCell"]);
            Assert.AreEqual("Color", _stringAttributesCreated["D"]["HoverRow"]);
            Assert.AreEqual("", _stringAttributesCreated["D"]["FocusCell"]);
            Assert.AreEqual("ClearSelection+Grid.SelectRow(Row,!Row.Selected)", _stringAttributesCreated["D"]["OnFocus"]);
            Assert.AreEqual(1, _intAttributesCreated["D"]["NoColorState"]);
        }

        [TestMethod]
        public void InitializeGridLayout_ValidRenderingTypeUseGrouping_GroupingSpecificDataSet()
        {
            // Arrange
            _useGroupingParameter = true;
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridLayout(GridBase.RenderingTypes.Combined);

            // Assert
            Assert.AreEqual("Grouping", _stringAttributesCreated["Cfg"]["MainCol"]);
            Assert.AreEqual("Grouping", _stringAttributesCreated["Header"]["Grouping"]);
            Assert.IsTrue(_substructsCreated.Contains("C"));
            Assert.AreEqual("Grouping", _stringAttributesCreated["C"]["Name"]);
            Assert.AreEqual("Text", _stringAttributesCreated["C"]["Type"]);
            Assert.AreEqual(0, _intAttributesCreated["C"]["CanMove"]);
            Assert.AreEqual(false, _booleanAttributesCreated["C"]["CanEdit"]);
        }

        [TestMethod]
        public void InitializeGridData_InvalidRenderingType_Throws()
        {
            // Arrange
            var grid = CreateGridBase();

            // Act
            Action action = () => grid.InitializeGridData(GridBase.RenderingTypes.None);

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
        public void InitializeGridData_Always_CreatesCorrectDataStructure()
        {
            // Arrange
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridData(GridBase.RenderingTypes.Combined);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Body"));
            Assert.IsTrue(_substructsCreated.Contains("B"));
            Assert.IsTrue(_substructsCreated.Contains("I"));
            Assert.AreEqual("Totals", _stringAttributesCreated["I"]["Grouping"]);
            Assert.AreEqual(false, _booleanAttributesCreated["I"]["CanEdit"]);
            Assert.AreEqual("Summary", _stringAttributesCreated["I"]["Def"]);

            Assert.AreEqual(0, grid.Level);
            Assert.AreEqual("I", grid.Levels[grid.Level].Name);
        }

        [TestMethod]
        public void InitializeGridData_DataRenderingType_CreatesCfg()
        {
            // Arrange
            var grid = CreateGridBase();

            // Act
            grid.InitializeGridData(GridBase.RenderingTypes.Data);

            // Assert
            Assert.IsTrue(_substructsCreated.Contains("Cfg"));
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
            Assert.AreEqual(periodData.PeriodID.ToString(), result);
        }
    }
}
