using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelDataCache;
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
            gridBase.AddPeriodColumns(_periodsParameter);

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
            gridBase.AddPeriodColumns(_periodsParameter);

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
            gridBase.AddPeriodColumns(_periodsParameter);

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
            gridBase.AddPeriodColumns(_periodsParameter);

            // Assert
            Assert.AreEqual(0, attributes.Count);
        }
    }
}
