using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CADataCache;
using CostDataValues;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkEnginePPM.Tests.TestDoubles.CADataCache;

namespace WorkEnginePPM.Tests.WebServices.CADataCache
{
    [TestClass]
    public class CADataCacheGridBaseTest
    {
        private const int _arraySize = 64;

        private IDisposable _shimsContext;

        private int _rowId;
        private bool _showFTEs;
        private bool _useQuantity;
        private bool _useCost;
        private bool _showCostDetailed;
        private int _pmoAdmin;
        private IList<clsColDisp> _columns;
        private IList<CATGRow> _displayList;
        private GridRenderingTypes _renderingType;
        private CADataCacheGridBaseTestDouble _testDouble;

        private IList<clsPeriodData> _periods;
        private clsDetailRowData _detailRow;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            _showFTEs = true;
            _useQuantity = true;
            _useCost = true;
            _showCostDetailed = true;
            _pmoAdmin = 0;

            _renderingType = GridRenderingTypes.Combined;

            _columns = new[]
            {
                new clsColDisp { m_id = (int)FieldIDs.FTOT_FID },
                new clsColDisp { m_id = (int)FieldIDs.PI_FID }
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
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        private CADataCacheGridBaseTestDouble CreateTestDouble()
        {
            return new CADataCacheGridBaseTestDouble(
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
        public void TryGetDataFromDetailRowDataField_UnknownField_EmptyValue()
        {
            // Arrange
            const int unknownFieldId = -1;
            string value;
            var grid = CreateTestDouble();

            // Act
            var result = grid.TryGetDataFromDetailRowDataField(_detailRow, unknownFieldId, out value);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(" ", value);
        }
    }
}
