using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
using ModelDataCache.Fakes;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using WorkEnginePPM.Tests.TestDoubles;

namespace WorkEnginePPM.Tests.WebServices.ModelDataCache
{
    [TestClass]
    public class GridBaseTest
    {
        private IDisposable _shimsContext;

        private ShimCStruct _header1Shim;
        private ShimCStruct _header2Shim;
        private ShimCStruct _periodColsShim;
        
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
        private bool _showCostDetailed;
        private int _fromPeriodIndexParameter;
        private int _toPeriodIndexParameter;

        private IList<PeriodData> _periodsParameter;
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
            _showCostDetailed = false;
            _fromPeriodIndexParameter = 0;
            _toPeriodIndexParameter = int.MaxValue;

            _periodsParameter = new PeriodData[]
            {
                new PeriodData
                {
                    PeriodID = 18,
                    PeriodName = "test-1"
                },

                new PeriodData
                {
                    PeriodID = 46,
                    PeriodName = "test-2"
                }
            };

            _detailRowParameter = new DetailRowData(64)
            {
                m_lev = 1,
                bSelected = true,
                bRealone = true,
                bGotChildren = true
            };

            _header1Shim = new ShimCStruct();
            _header2Shim = new ShimCStruct();
            _periodColsShim = new ShimCStruct();

            ShimCStruct.AllInstances.CreateSubStructString = (instance, name) => new ShimCStruct();
        }

        private GridBaseTestDouble CreateGridBase()
        {
            return new GridBaseTestDouble(
                _header1Shim, 
                _header2Shim, 
                _periodColsShim,

                _useGroupingParameter,
                _showFTEsParameter,
                _showGanttParameter,
                _dateStartParameter,
                _dateEndParameter,
                _sortFieldsParameter,
                _detFreezeParameter,
                _useQuantityParameter,
                _useCostParameter,
                _showCostDetailed,
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
        public void AddPeriodColumn_UseQuantity_Header1AttributesAdded()
        {
            // Arrange
            _useQuantityParameter = true;

            var attributes = new Dictionary<string, string>();

            _header1Shim.CreateStringAttrStringString = (name, value) =>
            {
                attributes.Add(name, value);
            };

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddPeriodColumnsTest(_periodsParameter);

            // Assert
            Assert.AreEqual(_periodsParameter.Count, attributes.Count);
            for (var i = 0; i < _periodsParameter.Count; i++)
            {
                Assert.AreEqual(_periodsParameter[i].PeriodName, attributes["P" + (i + 1) + "V"]);
            }
        }

        [TestMethod]
        public void AddPeriodColumn_NotUseQuantity_Header1AttributesAdded()
        {
            // Arrange
            var attributes = new Dictionary<string, string>();

            _header1Shim.CreateStringAttrStringString = (name, value) =>
            {
                attributes.Add(name, value);
            };

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddPeriodColumnsTest(_periodsParameter);

            // Assert
            Assert.AreEqual(_periodsParameter.Count, attributes.Count);
            for (var i = 0; i < _periodsParameter.Count; i++)
            {
                Assert.AreEqual(_periodsParameter[i].PeriodName, attributes["P" + (i + 1) + "C"]);
            }
        }

        [TestMethod]
        public void AddPeriodColumn_UseQuantity_Header2AttributesAdded()
        {
            // Arrange
            _useQuantityParameter = true;
            var attributes = new Dictionary<string, string>();

            _header2Shim.CreateStringAttrStringString = (name, value) =>
            {
                attributes.Add(name, value);
            };

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddPeriodColumnsTest(_periodsParameter);

            // Assert
            Assert.AreEqual(_periodsParameter.Count, attributes.Count);
            for (var i = 0; i < _periodsParameter.Count; i++)
            {
                Assert.AreEqual(" Qty ", attributes["P" + (i + 1) + "V"]);
            }
        }

        [TestMethod]
        public void AddPeriodColumn_NotUseQuantity_Header2AttributesAdded()
        {
            // Arrange
            var attributes = new Dictionary<string, string>();

            _header2Shim.CreateStringAttrStringString = (name, value) =>
            {
                attributes.Add(name, value);
            };

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddPeriodColumnsTest(_periodsParameter);

            // Assert
            Assert.AreEqual(0, attributes.Count);
        }

        [TestMethod]
        public void TryGetDataFromDetailRowDataField_UnknownField_EmptyValue()
        {
            // Arrange
            const int unknownFieldId = -1;
            string value;
            var grid = CreateGridBase();

            // Act
            var result = grid.TryGetDataFromDetailRowDataField(_detailRowParameter, unknownFieldId, out value);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(" ", value);
        }

        [TestMethod]
        public void TryGetDataFromDetailRowDataField_StartDateFieldWithNoDate_ReturnsFalseWithNullValue()
        {
            // Arrange
            const int fieldId = 5;
            _detailRowParameter.Det_Start = DateTime.MinValue;
            string value;
            var grid = CreateGridBase();

            // Act
            var result = grid.TryGetDataFromDetailRowDataField(_detailRowParameter, fieldId, out value);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(value);
        }

        [TestMethod]
        public void TryGetDataFromDetailRowDataField_EndDateFieldWithNoDate_ReturnsFalseWithNullValue()
        {
            // Arrange
            const int fieldId = 6;
            _detailRowParameter.Det_Start = DateTime.MinValue;
            string value;
            var grid = CreateGridBase();

            // Act
            var result = grid.TryGetDataFromDetailRowDataField(_detailRowParameter, fieldId, out value);

            // Assert
            Assert.IsFalse(result);
            Assert.IsNull(value);
        }

        [TestMethod]
        public void TryGetDataFromDetailRowDataField_FieldBetween11801And11805_ReturnsValueFromText_OCVal()
        {
            // Arrange
            const int fieldId = 11802;
            _detailRowParameter.Text_OCVal = new string[3];
            _detailRowParameter.Text_OCVal[2] = "test-text";

            string value;
            var grid = CreateGridBase();

            // Act
            var result = grid.TryGetDataFromDetailRowDataField(_detailRowParameter, fieldId, out value);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(_detailRowParameter.Text_OCVal[2], value);
        }

        [TestMethod]
        public void TryGetDataFromDetailRowDataField_FieldBetween11811And11815_ReturnsValueFromTXVal()
        {
            // Arrange
            const int fieldId = 11813;
            _detailRowParameter.TXVal = new string[4];
            _detailRowParameter.TXVal[3] = "test-text";

            string value;
            var grid = CreateGridBase();

            // Act
            var result = grid.TryGetDataFromDetailRowDataField(_detailRowParameter, fieldId, out value);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(_detailRowParameter.TXVal[3], value);
        }

        [TestMethod]
        public void RenderToXML_RenderingTypeInvalid_Throws()
        {
            // Arrange
            var grid = CreateGridBase();

            // Act
            Action action = () => grid.RenderToXml(GridBase.RenderingTypes.None);

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
        public void RenderToXML_Always_InitializesGridAndRendersIt()
        {
            // Arrange
            var grid = CreateGridBase();
            string structNameUsed = null;
            ShimCStruct.AllInstances.InitializeString = (element, name) =>
            {
                structNameUsed = name;
            };

            ShimCStruct.AllInstances.XML = (element) =>
            {
                return string.Empty;
            };

            // Act
            var xml = grid.RenderToXml(GridBase.RenderingTypes.Layout);

            // Assert
            Assert.AreEqual("Grid", structNameUsed);
        }

        [TestMethod]
        public void RenderToXML_Layout_RendersGridLayout()
        {
            // Arrange
            const GridBase.RenderingTypes renderingType = GridBase.RenderingTypes.Layout;
            var grid = CreateGridBase();

            // Act
            var xml = grid.RenderToXml(renderingType);

            // Assert
            Assert.AreEqual(1, grid.InitializeGridLayoutCalls.Count);
            Assert.IsTrue(grid.InitializeGridLayoutCalls.Contains(renderingType));
            Assert.AreEqual(1, grid.FinalizeGridLayoutCalls.Count);
            Assert.IsTrue(grid.FinalizeGridLayoutCalls.Contains(renderingType));
        }

        [TestMethod]
        public void RenderToXML_LayoutPeriodsNotNull_AddsPeriodColumns()
        {
            // Arrange
            const GridBase.RenderingTypes renderingType = GridBase.RenderingTypes.Layout;
            var periodsData = Enumerable.Empty<PeriodData>();

            var grid = CreateGridBase();
            grid.AddPeriodsData(periodsData);

            // Act
            var xml = grid.RenderToXml(renderingType);

            // Assert
            Assert.AreEqual(1, grid.AddPeriodColumnsCalls.Count);
            Assert.IsTrue(grid.AddPeriodColumnsCalls[0].SequenceEqual(periodsData));
        }

        [TestMethod]
        public void RenderToXML_Data_GridDataInitialized()
        {
            // Arrange
            const GridBase.RenderingTypes renderingType = GridBase.RenderingTypes.Data;
            var grid = CreateGridBase();

            // Act
            var xml = grid.RenderToXml(renderingType);

            // Assert
            Assert.AreEqual(1, grid.InitializeGridDataCalls.Count);
            Assert.IsTrue(grid.InitializeGridDataCalls[0] == renderingType);
        }

        [TestMethod]
        public void RenderToXML_DataDetailRowsNotNull_AddsDetailRows()
        {
            // Arrange
            const GridBase.RenderingTypes renderingType = GridBase.RenderingTypes.Data;
            var detailsRows = new DetailRowData[] 
            {
                new DetailRowData(10) { bRealone = true },
                new DetailRowData(15) { bRealone = true }
            };

            var grid = CreateGridBase();
            grid.AddDetailRowsData(detailsRows);

            // Act
            var xml = grid.RenderToXml(renderingType);

            // Assert
            Assert.AreEqual(detailsRows.Length, grid.AddDetailRowCalls.Count);
            for (var i = 0; i < detailsRows.Length; i++)
            {
                Assert.IsTrue(grid.AddDetailRowCalls[i].Item1 == detailsRows[i]);
                Assert.IsTrue(grid.AddDetailRowCalls[i].Item2 == i);
            }
        }
    }
}
