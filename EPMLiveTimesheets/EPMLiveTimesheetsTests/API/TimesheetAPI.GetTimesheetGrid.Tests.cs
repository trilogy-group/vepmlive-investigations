using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Xml;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveTimesheets.Tests;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets.Fakes;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPIGetTimesheetGridTests : SheetTestBase
    {
        private const int UserId = 23;
        private static readonly string XmlSample = $"<root GridType=\"10\" Period=\"may\" GridId=\"91\" Editable=\"true\" UserId=\"{UserId}\"></root>";

        [TestMethod]
        public void GetTimesheetGrid_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();

            // Act
            var message = TimesheetAPI.GetTimesheetGrid(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual(
                Resource.GetTimesheetGrid_Called_SqlDisposed_ExpectedResult,
                message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
        }

        private void SetupShims()
        {
            var readNum = -1;
            ShimSqlDataReader.AllInstances.Read = instance =>
            {
                readNum++;
                return readNum < 3;
            };

            ShimSqlDataReader.AllInstances.GetInt32Int32 = (instance, num) => 0;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (instance, num) => string.Empty;
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => true.ToString();
            ShimTimesheetAPI.CheckNonTeamMemberAllocationSPWebStringStringString
                = (_, __, ___, ____) => { };
            ShimTimesheetAPI.GetPeriodDaysArraySqlConnectionTimesheetSettingsSPWebString =
                (cn, settings, web, sPeriod) =>
                {
                    return new ArrayList(new [] { new DateTime(2018, 01, 22) });
                };

            var dataSet = new DataSet();

            var table0 = new DataTable();
            dataSet.Tables.Add(table0);

            var table1 = new DataTable();
            table1.Columns.Add("SUBMITTED");
            var row10 = table1.NewRow();
            row10["SUBMITTED"] = "True";
            table1.Rows.Add(row10);
            dataSet.Tables.Add(table1);

            var table2 = new DataTable();
            table2.Columns.Add("TS_ITEM_UID");
            var row20 = table2.NewRow();
            row20["TS_ITEM_UID"] = "100";
            table2.Rows.Add(row20);
            var row21 = table2.NewRow();
            row21["TS_ITEM_UID"] = "102";
            row21["TS_ITEM_UID"] = "102";
            table2.Rows.Add(row21);
            dataSet.Tables.Add(table2);
            ShimTimesheetAPI.GetTSDataSetSqlConnectionSPWebSPUserString = (connection, web, user, period) => dataSet;

            ShimTimesheetAPI.CreateTSRowXmlDocumentRefDataSetDataRowArrayListArrayListTimesheetSettingsBooleanSPWeb = 
                (
                    ref XmlDocument docData,
                    DataSet set,
                    DataRow dataRow,
                    ArrayList lookups,
                    ArrayList periods,
                    TimesheetSettings settings,
                    bool edit,
                    SPWeb web
                ) =>
            {
                var node = docData.FirstChild.FirstChild;
                return node;
            };

            ShimMyWorkReportData.ConstructorGuid = (instance, __) =>
            {
                new ShimMyWorkReportData(instance)
                {
                    ExecuteSqlString = _ => new DataTable()
                };
            };

            ShimTimesheetSettings.ConstructorSPWeb = (_, __) => { };
        }
    }
}