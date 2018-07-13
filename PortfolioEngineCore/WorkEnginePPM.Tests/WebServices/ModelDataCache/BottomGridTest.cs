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
    public class BottomGridTest
    {
        private IDisposable _shimsContext;

        private IDictionary<string, string> _stringAttributesCreated;
        private IDictionary<string, bool> _booleanAttributesCreated;
        private IDictionary<string, int> _intAttributesCreated;
        private IDictionary<string, double> _doubleAttributesCreated;

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

            _stringAttributesCreated = new Dictionary<string, string>();
            _booleanAttributesCreated = new Dictionary<string, bool>();
            _intAttributesCreated = new Dictionary<string, int>();
            _doubleAttributesCreated = new Dictionary<string, double>();

            ShimCStruct.AllInstances.CreateSubStructString = (instance, subStructName) =>
                new ShimCStruct
                {
                    CreateStringAttrStringString = (name, value) =>
                    {
                        _stringAttributesCreated.Add(name, value);
                    },
                    CreateBooleanAttrStringBoolean = (name, value) =>
                    {
                        _booleanAttributesCreated.Add(name, value);
                    },
                    CreateIntAttrStringInt32 = (name, value) =>
                    {
                        _intAttributesCreated.Add(name, value);
                    },
                    CreateDoubleAttrStringDouble = (name, value) =>
                    {
                        _doubleAttributesCreated.Add(name, value);
                    },
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
            Assert.AreEqual(idExpected.ToString(), _stringAttributesCreated["id"]);
            Assert.AreEqual("255,255,255", _stringAttributesCreated["Color"]);
            Assert.AreEqual(false, _booleanAttributesCreated["CanEdit"]);
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
            Assert.AreEqual(_detailRowParameter.sName, _stringAttributesCreated["Grouping"]);
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
            _detailRowParameter.bRealone = true;
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(_detailRowParameter, 0);

            // Assert
            Assert.AreEqual("255,255,255", _stringAttributesCreated["Color"]);
        }
    }
}
