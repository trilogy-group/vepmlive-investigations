using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Linq;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveTimesheets.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets.Fakes;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPIGetTimesheetApprovalsGridTests : SheetTestBase
    {
        private const int UserId = 23;
        private static readonly string XmlSample = $"<root GridType=\"10\" Period=\"may\" GridId=\"91\" Editable=\"true\" UserId=\"{UserId}\"></root>";

        [TestMethod]
        public void GetTimesheetApprovalsGrid_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();

            // Act
            var message = TimesheetAPI.GetTimesheetApprovalsGrid(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual(
                Resource.GetTimesheetApprovalsGrid_Called_SqlDisposed_ExpectedResult,
                message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(1, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataAdaptersDisposed.Count);
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
                (_, __, ___, ____) => new ArrayList(new [] { new DateTime(2018, 01, 22) });

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