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
using System.Collections.Generic;
using System.Reflection;
using System.Data.Fakes;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPIGetTimesheetGridTests : SheetTestBase
    {
        private const int UserId = 23;
        private static readonly string XmlSample = $"<root GridType=\"10\" Period=\"may\" GridId=\"91\" Editable=\"true\" UserId=\"{UserId}\"></root>";
        private int TSItemHour = 0;

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
        [TestMethod]
        public void GetTimesheetGrid_Hide_StrikeItem_With_No_Hours()
        {
            // Arrange
            TSItemHour = 0;

            // Act,Assert
            ArangeActAssert();
        }

        [TestMethod]
        public void GetTimesheetGrid_Hide_StrikeItem_With_Hours()
        {
            // Arrange
            TSItemHour = 1;

            // Act,Assert
            ArangeActAssert();
        }

        private void ArangeActAssert()
        {
            // Arrange
            SetupShims();
            
            // Act
            var message = TimesheetAPI.GetTimesheetGrid(XmlSample, _sharepointShims.WebShim);

            // Assert
            if (TSItemHour == 0)
            {
                Assert.AreEqual(
                    Resource.GetTimesheetGrid_Hide_StrikeItem_With_No_Hours_ExpectedResult,
                    message);
            }
            else
            {
                Assert.AreEqual(
                    Resource.GetTimesheetGrid_Hide_StrikeItem_With_Hours_ExpectedResult,
                    message);
            }
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
                    return new ArrayList(new[] { new DateTime(2018, 01, 22) });
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
            table2.Columns.Add("tsuid");
            table2.Columns.Add("TS_ITEM_HOURS");
            table2.Columns.Add("ITEM_ID");
            
            table2.Columns.Add("LIST_UID");
            table2.Columns.Add("PROJECT_ID");
            table2.Columns.Add("TITLE");
            var row20 = table2.NewRow();
            row20["TS_ITEM_UID"] = "100";
            row20["tsuid"] = Guid.Empty;
            row20["TS_ITEM_HOURS"] = TSItemHour;
            row20["ITEM_ID"] = "100";
            row20["LIST_UID"] = "100";
            row20["TITLE"] = "SameName";
            row20["PROJECT_ID"] = "40";
            table2.Rows.Add(row20);
            var row21 = table2.NewRow();
            row21["TS_ITEM_UID"] = "102";
            row21["tsuid"] = Guid.Empty;
            row21["TS_ITEM_HOURS"] = TSItemHour;
            row21["ITEM_ID"] = "100";
            row21["LIST_UID"] = "100";
            row21["TITLE"] = "SameName";
            row21["PROJECT_ID"] = "40";
            table2.Rows.Add(row21);
            dataSet.Tables.Add(table2);


            ShimTimesheetAPI.GetTSDataSetSqlConnectionSPWebSPUserString = (connection, web, user, period) => dataSet;
            ShimDataSet.AllInstances.TablesGet = (_ds) =>
            {
                // fake DataTableCollection of data set
                return new ShimDataTableCollection()
                {
                    ItemGetInt32 = (S) =>
                    {
                        switch (S)
                        {
                            case 1:
                                return table1;
                            default:
                                return table2;
                        }
                    },
                };
            };
            ShimDataTable.AllInstances.SelectString = (_dt, _string) =>
            {
                return table2.Select();
            };
            ShimTimesheetAPI.CreateTSRowXmlDocumentRefDataSetDataRowArrayListArrayListTimesheetSettingsBooleanSPWeb =
                (ref XmlDocument docData,
                DataSet set,
                DataRow dataRow,
                ArrayList lookups,
                ArrayList periods,
                TimesheetSettings settings,
                bool edit,
                SPWeb web) =>
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