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

        private DetailRowData _detailRowDataParameter;
        private int _rowIdParameter;
        private bool _useGroupingParameter;
        private bool _showFteParameter;
        private bool _showGanttParameter;
        private SortFieldDefn[] _detColParameter;
        private int _minPParameter;
        private int _maxPParameter;
        private bool _useQuantityParameter;
        private bool _useCostParameter;
        private bool _roundCostParameter;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

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

            _detailRowDataParameter = new DetailRowData(64)
            {
                m_lev = 1,
                bSelected = true
            };
            _rowIdParameter = 0;
            _useGroupingParameter = false;
            _showFteParameter = false;
            _showGanttParameter = false;
            _detColParameter = new SortFieldDefn[] { };
            _minPParameter = 0;
            _maxPParameter = 0;
            _useQuantityParameter = false;
            _useCostParameter = false;
            _roundCostParameter = false;
        }

        private TopGridBaseTestDouble CreateGridBase()
        {
            return new TopGridBaseTestDouble();
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
            gridBase.AddDetailRow(
                _detailRowDataParameter,
                _rowIdParameter,
                _useGroupingParameter,
                _showFteParameter,
                _showGanttParameter,
                _detColParameter,
                _minPParameter,
                _maxPParameter,
                _useQuantityParameter,
                _useCostParameter,
                _roundCostParameter
            );

            // Assert
            Assert.AreEqual(_rowIdParameter.ToString(), _stringAttributesCreated["id"]);
            Assert.AreEqual("1", _stringAttributesCreated["Select"]);
            Assert.AreEqual(true, _booleanAttributesCreated["SelectCanEdit"]);
            Assert.AreEqual(false, _booleanAttributesCreated["CanEdit"]);
            Assert.AreEqual(1, _intAttributesCreated["NoColorState"]);
        }

        [TestMethod]
        public void AddDetailRow_Realone_AddsColor()
        {
            // Arrange
            _detailRowDataParameter.bRealone = true;
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(
                _detailRowDataParameter,
                _rowIdParameter,
                _useGroupingParameter,
                _showFteParameter,
                _showGanttParameter,
                _detColParameter,
                _minPParameter,
                _maxPParameter,
                _useQuantityParameter,
                _useCostParameter,
                _roundCostParameter
            );

            // Assert
            Assert.AreEqual("255,255,255", _stringAttributesCreated["Color"]);
        }

        [TestMethod]
        public void AddDetailRow_LevelNotEqualTo1_AddsCanFilterAttribute()
        {
            // Arrange
            _detailRowDataParameter.m_lev = 2;
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(
                _detailRowDataParameter,
                _rowIdParameter,
                _useGroupingParameter,
                _showFteParameter,
                _showGanttParameter,
                _detColParameter,
                _minPParameter,
                _maxPParameter,
                _useQuantityParameter,
                _useCostParameter,
                _roundCostParameter
            );

            // Assert
            Assert.AreEqual(2, _intAttributesCreated["CanFilter"]);
        }

        [TestMethod]
        public void AddDetailRow_UseGroupping_AddsSpecificAttributes()
        {
            // Arrange
            _useGroupingParameter = true;
            _detailRowDataParameter.sName = "test-name";
            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(
                _detailRowDataParameter,
                _rowIdParameter,
                _useGroupingParameter,
                _showFteParameter,
                _showGanttParameter,
                _detColParameter,
                _minPParameter,
                _maxPParameter,
                _useQuantityParameter,
                _useCostParameter,
                _roundCostParameter
            );

            // Assert
            Assert.AreEqual(_detailRowDataParameter.sName, _stringAttributesCreated["xGrouping"]);
        }

        [TestMethod]
        public void AddDetailRow_ShowGanttAndNoChildren_AddsSpecificAttributes()
        {
            // Arrange
            _showGanttParameter = true;
            _detailRowDataParameter.bGotChildren = false;

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(
                _detailRowDataParameter,
                _rowIdParameter,
                _useGroupingParameter,
                _showFteParameter,
                _showGanttParameter,
                _detColParameter,
                _minPParameter,
                _maxPParameter,
                _useQuantityParameter,
                _useCostParameter,
                _roundCostParameter
            );

            // Assert
            Assert.AreEqual("GanttBlue", _stringAttributesCreated["GGanttClass"]);
        }

        [TestMethod]
        public void AddDetailRow_NoGanttUseCostNoRounding_CreatesAttributesForMinToMaxP()
        {
            // Arrange
            _showGanttParameter = false;
            _useCostParameter = true;

            for (var i = _minPParameter; i <= _maxPParameter; i++)
            {
                _detailRowDataParameter.zCost[i] = 1.1 * i;
            }

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(
                _detailRowDataParameter,
                _rowIdParameter,
                _useGroupingParameter,
                _showFteParameter,
                _showGanttParameter,
                _detColParameter,
                _minPParameter,
                _maxPParameter,
                _useQuantityParameter,
                _useCostParameter,
                _roundCostParameter
            );

            // Assert
            for (var i = _minPParameter; i <= _maxPParameter; i++)
            {
                Assert.AreEqual(_detailRowDataParameter.zCost[i], _doubleAttributesCreated["P" + i + "C"]);
            }
        }

        [TestMethod]
        public void AddDetailRow_NoGanttUseCostWithRounding_CreatesAttributesForMinToMaxP()
        {
            // Arrange
            _showGanttParameter = false;
            _useCostParameter = true;
            _roundCostParameter = true;

            for (var i = _minPParameter; i <= _maxPParameter; i++)
            {
                _detailRowDataParameter.zCost[i] = 1.1 * i;
            }

            var gridBase = CreateGridBase();

            // Act
            gridBase.AddDetailRow(
                _detailRowDataParameter,
                _rowIdParameter,
                _useGroupingParameter,
                _showFteParameter,
                _showGanttParameter,
                _detColParameter,
                _minPParameter,
                _maxPParameter,
                _useQuantityParameter,
                _useCostParameter,
                _roundCostParameter
            );

            // Assert
            for (var i = _minPParameter; i <= _maxPParameter; i++)
            {
                Assert.AreEqual((double)(int)_detailRowDataParameter.zCost[i], _doubleAttributesCreated["P" + i + "C"]);
            }
        }
    }
}
