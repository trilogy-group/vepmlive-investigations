using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Reflection;
using EPMLiveTimesheets.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPIFillTimesheetItemsDatasetTests : SheetTestBase
    {
        private DataSet _dataSet;

        [TestMethod]
        public void FillTimesheetItemsDataset_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();
            var method = typeof(TimesheetAPI).GetMethod(
                "FillTimesheetItemsDataset", 
                BindingFlags.Static | BindingFlags.NonPublic);
            var dataSet = new DataSet();

            // Act
            method.Invoke(null, new object[] 
            {
                "1",
                dataSet,
                (SqlConnection)_adoShims.ConnectionShim
            });

            // Assert
            Assert.AreEqual(dataSet, _dataSet);
            Assert.AreEqual(1, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataAdaptersDisposed.Count);
        }

        private void SetupShims()
        {
            ShimDbDataAdapter.AllInstances.FillDataSet = (adapter, dataSet) => 
            {
                _dataSet = dataSet;
                return 0;
            };
        }
    }
}