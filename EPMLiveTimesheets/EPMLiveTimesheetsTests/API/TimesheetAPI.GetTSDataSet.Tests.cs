using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveTimesheets.Tests;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets.Fakes;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPIGetTSDataSetTests : SheetTestBase
    {
        private const string XmlSample = "<root ID=\"10\" List=\"100\"><a></a></root>";
        private const int UserId = 23;
        private const int StatusId = 5;
        private const int PictureId = 7;
        private const int ApprovalStatusId = 9;
        private const string Result = "result-sample";
        private const string ResultText = "result-text-sample";
        private const int ResultFieldIndex = 2;
        private const int ResultTextFieldIndex = 3;

        private static readonly Guid Guid1 = new Guid("0F61D137-5C75-4F38-9F8E-E62ED8AA3909");
        private DataSet _dataSet = new DataSet();

        [TestMethod]
        public void GetTSDataSet_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();
            var method = typeof(TimesheetAPI).GetMethod(
                "GetTSDataSet",
                BindingFlags.Static | BindingFlags.NonPublic);

            // Act
            var result = method.Invoke(null, new object[] 
            {
                (SqlConnection)_adoShims.ConnectionShim,
                (SPWeb)_sharepointShims.WebShim,
                (SPUser)_sharepointShims.UserShim,
                "Jun 14"
            });

            // Assert
            var dataSet = result as DataSet;
            Assert.IsNotNull(dataSet);
            Assert.AreEqual(_dataSet, dataSet);
            Assert.AreEqual(4, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(2, _adoShims.DataReadersDisposed.Count);
        }

        private void SetupShims()
        {
            ShimMyWorkReportData.ConstructorGuid = (instance, guid) => {};

            ShimTimesheetAPI.GenerateTSFromPastSqlConnectionSPWebSPUserStringMyWorkReportData
                = (SqlConnection cn, 
                    SPWeb web,
                    SPUser user,
                    string period,
                    MyWorkReportData rptData) =>
                {
                    return Guid1;
                };

            ShimTimesheetAPI.iiGetTSDataSqlConnectionSPWebStringGuidMyWorkReportDataString
                = (SqlConnection cn,
                    SPWeb web,
                    string sPeriod,
                    Guid tsuid,
                    MyWorkReportData rptData,
                    string userId) =>
                {
                    return _dataSet;
                };
        }
    }
}