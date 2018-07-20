using System;
using System.Data.SqlClient.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PortfolioEngineCore.Tests.Analyzers
{
    [TestClass]
    public class CostAnalyzerDataTest
    {
        private IDisposable _shimsContext;
        private ShimSqlConnection _sqlConnectionShim;
        private int _readsCountTotal;
        private int _currentReadNumber;
        private int _viewId;

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            _readsCountTotal = 1;
            _sqlConnectionShim = new ShimSqlConnection();
            _viewId = 2;

            ShimSqlCommand.AllInstances.ExecuteReader = (instance) => new ShimSqlDataReader
            {
                Read = () => _currentReadNumber++ < _readsCountTotal,
                ItemGetString = columnName =>
                                    columnName == "VIEW_UID" ? (object)_viewId :
                                    DBNull.Value
            };
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext.Dispose();
        }

        [TestMethod]
        public void CheckIfCostViewsExist_Always_CorrectSqlExecuted()
        {
            // Arrange
            string commandTextUsed = null;
            ShimSqlCommand.ConstructorStringSqlConnection = (instance, commandText, sqlConnection) =>
            {
                commandTextUsed = commandText;
            };

            // Act
            CostAnalyzerData.CheckIfCostViewsExist(_sqlConnectionShim.Instance);

            // Assert
            Assert.AreEqual("SELECT * FROM EPGT_COSTVIEW_DISPLAY", commandTextUsed);
        }

        [TestMethod]
        public void CheckIfCostViewsExist_RowsExist_ReturnsTrue()
        {
            // Arrange
            _readsCountTotal = 1;

            // Act
            var result = CostAnalyzerData.CheckIfCostViewsExist(_sqlConnectionShim.Instance);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckIfCostViewsExist_NoRowsExist_ReturnsFalse()
        {
            // Arrange
            _readsCountTotal = 0;

            // Act
            var result = CostAnalyzerData.CheckIfCostViewsExist(_sqlConnectionShim.Instance);

            // Assert
            Assert.IsFalse(result);
        }
    }
}