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
    public class TopGridBaseTest
    {
        private IDisposable _shimsContext;

        private IDictionary<string, string> _stringAttributesCreated;
        private IDictionary<string, bool> _booleanAttributesCreated;
        private IDictionary<string, int> _intAttributesCreated;
        private IDictionary<string, double> _doubleAttributesCreated;

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
        private bool _roundCostParameter;
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
            _roundCostParameter = false;
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

        private TopGridBaseTestDouble CreateGridBase()
        {
            return new TopGridBaseTestDouble(
                _useGroupingParameter,
                _showFTEsParameter,
                _showGanttParameter,
                _dateStartParameter,
                _dateEndParameter,
                _sortFieldsParameter,
                _detFreezeParameter,
                _useQuantityParameter,
                _useCostParameter,
                _roundCostParameter,
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
        public void RemoveNastyCharacters_InputNull_Throws()
        {
            // Arrange
            const string input = null;
            var gridBase = CreateGridBase();

            try
            {
                // Act
                gridBase.RemoveNastyCharacters(input);
            }
            // Assert
            catch (ArgumentNullException)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void RemoveNastyCharacters_InputHasNastyCharacters_Removes()
        {
            // Arrange
            const string input = "valid" + "!@#$%^&*()_+-={}[]|:;'?/~` '\r\n\"\\";
            var gridBase = CreateGridBase();

            // Act
            var result = gridBase.RemoveNastyCharacters(input);

            // Assert
            Assert.AreEqual("valid", result);
        }

        [TestMethod]
        public void AddDetailRow_Always_AddsExpectedAttributes()
        {
            // Arrange
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRows(new[] { _detailRowParameter });

            // Assert
            Assert.AreEqual(_idParameter.ToString(), _stringAttributesCreated["id"]);
            Assert.AreEqual("1", _stringAttributesCreated["Select"]);
            Assert.AreEqual(true, _booleanAttributesCreated["SelectCanEdit"]);
            Assert.AreEqual(false, _booleanAttributesCreated["CanEdit"]);
            Assert.AreEqual(1, _intAttributesCreated["NoColorState"]);
        }

        [TestMethod]
        public void AddDetailRow_Realone_AddsColor()
        {
            // Arrange
            _detailRowParameter.bRealone = true;
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRows(new[] { _detailRowParameter });

            // Assert
            Assert.AreEqual("255,255,255", _stringAttributesCreated["Color"]);
        }

        [TestMethod]
        public void AddDetailRow_LevelNotEqualTo1_AddsCanFilterAttribute()
        {
            // Arrange
            _detailRowParameter.m_lev = 2;
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRows(new[] { _detailRowParameter });

            // Assert
            Assert.AreEqual(2, _intAttributesCreated["CanFilter"]);
        }

        [TestMethod]
        public void AddDetailRow_UseGroupping_AddsSpecificAttributes()
        {
            // Arrange
            _useGroupingParameter = true;
            _detailRowParameter.sName = "test-name";
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRows(new[] { _detailRowParameter });

            // Assert
            Assert.AreEqual(_detailRowParameter.sName, _stringAttributesCreated["xGrouping"]);
        }

        [TestMethod]
        public void AddDetailRow_ShowGanttAndNoChildren_AddsSpecificAttributes()
        {
            // Arrange
            _showGanttParameter = true;
            _detailRowParameter.bGotChildren = false;

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRows(new[] { _detailRowParameter });

            // Assert
            Assert.AreEqual("GanttBlue", _stringAttributesCreated["GGanttClass"]);
        }

        [TestMethod]
        public void AddDetailRow_NoGanttUseCostNoRounding_CreatesAttributesForMinToMaxP()
        {
            // Arrange
            _showGanttParameter = false;
            _useCostParameter = true;

            for (var i = _fromPeriodIndexParameter; i <= _toPeriodIndexParameter; i++)
            {
                _detailRowParameter.zCost[i] = 1.1 * i;
            }

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRows(new[] { _detailRowParameter });

            // Assert
            for (var i = _fromPeriodIndexParameter; i <= _fromPeriodIndexParameter; i++)
            {
                Assert.AreEqual(_detailRowParameter.zCost[i], _doubleAttributesCreated["P" + i + "C"]);
            }
        }

        [TestMethod]
        public void AddDetailRow_NoGanttUseCostWithRounding_CreatesAttributesForMinToMaxP()
        {
            // Arrange
            _showGanttParameter = false;
            _useCostParameter = true;
            _roundCostParameter = true;

            for (var i = _fromPeriodIndexParameter; i <= _toPeriodIndexParameter; i++)
            {
                _detailRowParameter.zCost[i] = 1.1 * i;
            }

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRows(new[] { _detailRowParameter });

            // Assert
            for (var i = _fromPeriodIndexParameter; i <= _toPeriodIndexParameter; i++)
            {
                Assert.AreEqual((double)(int)_detailRowParameter.zCost[i], _doubleAttributesCreated["P" + i + "C"]);
            }
        }
    }
}
