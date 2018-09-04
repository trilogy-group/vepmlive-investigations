using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Xml;
using EPMLiveTimesheets.Tests;
using Microsoft.SharePoint;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets.Fakes;
using TimeSheets.Log.Fakes;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPIGetWorkTests : SheetTestBase
    {
        private const string XmlSample = 
            "<root TSID=\"10\" SearchField=\"searchField\" SearchText=\"sample search text\" " +
                "OtherWork=\"True\" NonWork=\"True\"><Cfg></Cfg></root>";
        private const int UserId = 23;

        [TestMethod]
        public void GetWork_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();

            // Act
            var message = TimesheetAPI.GetWork(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual(Resource.GetWork_Called_SqlDisposed_ExpectedResult, message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataReadersDisposed.Count);
        }

        private void SetupShims()
        {
            ShimTimesheetSettings.ConstructorSPWeb = (instance, spWeb) => { };
            ShimLogger.WriteLogLoggerCategoryStringString = (categoryName, source, message) => { };
            _sharepointShims.SiteShim.RootWebGet = () => _sharepointShims.WebShim;

            ShimSqlDataReader.AllInstances.Read = instance => true;
            ShimSqlDataReader.AllInstances.GetStringInt32 = (instance, num) =>
            {
                if (num == 0)
                {
                    return UserId.ToString();
                }
                else if (num == 1)
                {
                    return "May 2017";
                }
                throw new Exception("Unexpected call to read.");
            };

            ShimTimesheetAPI.GetTSDataSetSqlConnectionSPWebSPUserString
                = (_, __, ___, ____) =>
                {
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
                    table2.Rows.Add(row21);
                    dataSet.Tables.Add(table2);

                    return dataSet;
                };

            ShimTimesheetAPI.GetPeriodDaysArraySqlConnectionTimesheetSettingsSPWebString
                = (_, __, ___, ____) =>
                {
                    var periods = new ArrayList();
                    periods.Add(new DateTime(2017, 04, 28));
                    return periods;
                };

            ShimTimesheetAPI.CreateTSRowXmlDocumentRefDataSetDataRowArrayListArrayListTimesheetSettingsBooleanSPWeb
                = (ref XmlDocument docData,
                    DataSet dsTS,
                    DataRow dr,
                    ArrayList arrLookups,
                    ArrayList arrPeriods,
                    TimesheetSettings settings,
                    bool bCanEdit,
                    SPWeb web) =>
                {
                    var node = docData.FirstChild.FirstChild;
                    return node;
                };
        }
    }
}