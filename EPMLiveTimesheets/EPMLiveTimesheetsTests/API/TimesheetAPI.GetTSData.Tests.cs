using System;
using System.Data;
using System.Linq;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveTimesheets.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets.Fakes;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPIGetTSDataTests : SheetTestBase
    {
        private const int UserId = 23;
        private static readonly string XmlSample =
            $"<root GridType=\"10\" Period=\"may\" GridId=\"91\" Editable=\"true\" UserId=\"{UserId}\"></root>";
        private static readonly Guid Guid1 = new Guid("0F61D137-5C75-4F38-9F8E-E62ED8AA3909");
        private DataSet _dataSet = new DataSet();

        [TestMethod]
        public void GetTSData_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();

            // Act
            var result = TimesheetAPI.GetTSData(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual("<NewDataSet />", result);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
        }

        private void SetupShims()
        {
            ShimMyWorkReportData.ConstructorGuid = (instance, guid) => { };

            ShimTimesheetAPI.GenerateTSFromPastSqlConnectionSPWebSPUserStringMyWorkReportData
                = (_, __, ___, ____, _____) => Guid1;

            ShimTimesheetAPI.iiGetTSDataSqlConnectionSPWebStringGuidMyWorkReportDataString
                = (_, __, ___, ____, _____, ______) => _dataSet;
        }
    }
}