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

namespace WorkEnginePPM.Tests.WebServices
{
    [TestClass]
    public class GridBaseTest
    {
        private IDisposable _shimsContext;

        private ShimCStruct _header1Shim;
        private ShimCStruct _header2Shim;
        private ShimCStruct _periodColsShim;
        private IList<PeriodData> _periodsParameter;
        private DetailRowData _detailRowParameter;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

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
                _periodColsShim
            );
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RenderToXML_RenderingTypeInvalid_Throws()
        {
            // Arrange
            var grid = CreateGridBase();

            // Act
            grid.RenderToXml(GridRenderingTypes.None);

            // Assert
            // ExpectedException - ArgumentException
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

            ShimCStruct.AllInstances.XML = element =>
            {
                return string.Empty;
            };

            // Act
            var xml = grid.RenderToXml(GridRenderingTypes.Layout);

            // Assert
            Assert.AreEqual("Grid", structNameUsed);
        }

        [TestMethod]
        public void RenderToXML_Layout_RendersGridLayout()
        {
            // Arrange
            const GridRenderingTypes renderingType = GridRenderingTypes.Layout;
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
            const GridRenderingTypes renderingType = GridRenderingTypes.Layout;
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
            const GridRenderingTypes renderingType = GridRenderingTypes.Data;
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
            const GridRenderingTypes renderingType = GridRenderingTypes.Data;
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
