using System;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Reflection;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveTimesheets.Tests;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPIGenerateTSFromPastTests : SheetTestBase
    {
        private static readonly Guid Guid1 = new Guid("BA04FE65-C83E-41D8-B81B-2172E35F585B");

        [TestMethod]
        public void GenerateTSFromPast_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();
            var method = typeof(TimesheetAPI).GetMethod(
                "GenerateTSFromPast",
                BindingFlags.Static | BindingFlags.NonPublic);

            // Act
            var result = method.Invoke(null, new object[]
            {
                (SqlConnection)_adoShims.ConnectionShim,
                (SPWeb)_sharepointShims.WebShim,
                (SPUser)_sharepointShims.UserShim,
                "1",
                (MyWorkReportData)new ShimMyWorkReportData()
            });

            // Assert
            Assert.IsInstanceOfType(result, typeof(Guid));
            Assert.IsTrue(result.ToString().Length == 36);
            Assert.AreEqual(4, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataAdaptersDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataReadersDisposed.Count);
        }

        private void SetupShims()
        {
            ShimSqlDataReader.AllInstances.Read = instance => true;

            ShimSqlDataReader.AllInstances.GetGuidInt32 = (_, __) => Guid1;

            var dataSetTable = new DataTable();
            dataSetTable.Columns.AddRange(new[]
            {
                new DataColumn("WEB_UID", typeof(Guid)),
                new DataColumn("LIST_UID", typeof(Guid)),
                new DataColumn("ITEM_ID", typeof(int)),
                new DataColumn("TITLE", typeof(string)),
                new DataColumn("PROJECT", typeof(string)),
                new DataColumn("PROJECT_ID", typeof(int)),
                new DataColumn("LIST", typeof(string)),
                new DataColumn("PROJECT_LIST_UID", typeof(Guid))
            });
            var dataSetRow = dataSetTable.NewRow();
            dataSetTable.Rows.Add(dataSetRow);

            ShimDbDataAdapter.AllInstances.FillDataSet = (_, dataSetArg) =>
            {
                dataSetArg.Tables.Add(dataSetTable);
                return 0;
            };

            var executeTable = new DataTable();
            executeTable.Columns.AddRange(new[]
            {
                new DataColumn("Timesheet", typeof(bool))
            });
            var executeRow = executeTable.NewRow();
            executeRow["Timesheet"] = true;
            executeTable.Rows.Add(executeRow);
            ShimMyWorkReportData.AllInstances.ExecuteSqlString = (_, sql) => executeTable;
        }
    }
}