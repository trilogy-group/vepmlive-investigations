using System;
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
    public class TimesheetAPIAutoAddWorkTests : SheetTestBase
    {
        private const int UserId = 23;
        private const int StatusId = 5;
        private const int PictureId = 7;
        private static readonly string XmlSample = $"<root ID=\"10\" UserId=\"{UserId}\"><a></a></root>";
        private const int ApprovalStatusId = 9;
        private const string Result = "result-sample";
        private const string ResultText = "result-text-sample";
        private const int ResultFieldIndex = 2;
        private const int ResultTextFieldIndex = 3;

        [TestMethod]
        public void AutoAddWork_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();

            // Act
            var message = TimesheetAPI.AutoAddWork(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual(
                "<AutoAddWork Status=\"0\"></AutoAddWork>",
                message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(3, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(3, _adoShims.DataReadersDisposed.Count);
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
            ShimSqlDataReader.AllInstances.GetStringInt32 = (instance, num) =>
            {
                if (readNum == 0)
                {
                    if (num == ResultFieldIndex)
                    {
                        return Result;
                    }
                    else if (num == ResultTextFieldIndex)
                    {
                        return ResultText;
                    }
                }
                throw new Exception("Unexpected call to GetString.");
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => true.ToString();
            ShimTimesheetAPI.CheckNonTeamMemberAllocationSPWebStringStringString
                = (_, __, ___, ____) => { };

            ShimMyWorkReportData.ConstructorGuid = (instance, __) =>
            {
                var reportDataShim = new ShimMyWorkReportData(instance)
                {
                    ExecuteSqlString = _ => new DataTable()
                };
            };
        }
    }
}