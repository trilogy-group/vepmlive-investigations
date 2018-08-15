using System;
using System.Data.SqlClient.Fakes;
using System.Linq;
using EPMLiveCore.Fakes;
using EPMLiveTimesheets.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets.Fakes;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPICheckApproveStatusTests : SheetTestBase
    {
        private const string XmlSample = "<root ID=\"10\" List=\"100\"><a></a></root>";
        private const int UserId = 23;
        private const int StatusId = 5;
        private const int PictureId = 7;
        private const int ApprovalStatusId = 9;
        private const string Result = "result-sample";
        private const string ResultText = "result-text-sample";

        [TestMethod]
        public void CheckApproveStatus_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();

            // Act
            var message = TimesheetAPI.CheckApproveStatus(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual(
                "<ApproveStatus Result=\"0\" Status=\"5\" PercentComplete=\"7\" ErrorResult=\"result-sample\" " +
                "ResultText=\"result-text-sample\" ApprovalStatus=\"9\"></ApproveStatus>",
                message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(2, _adoShims.DataReadersDisposed.Count);
        }

        private void SetupShims()
        {
            var readNum = -1;
            ShimSqlDataReader.AllInstances.Read = instance =>
            {
                readNum++;
                return true;
            };

            ShimSqlDataReader.AllInstances.GetInt32Int32 = (instance, num) =>
            {
                if (readNum == 0)
                {
                    if (num == 0)
                    {
                        return StatusId;
                    }
                    else if (num == 1)
                    {
                        return PictureId;
                    }
                }
                else if (readNum == 1)
                {
                    if (num == 0)
                    {
                        return ApprovalStatusId;
                    }
                }
                throw new Exception("Unexpected call to GetInt32.");
            };
            ShimSqlDataReader.AllInstances.GetStringInt32 = (instance, num) =>
            {
                if (readNum == 0)
                {
                    if (num == 2)
                    {
                        return Result;
                    }
                    else if (num == 3)
                    {
                        return ResultText;
                    }
                }
                throw new Exception("Unexpected call to GetString.");
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => true.ToString();
            ShimTimesheetAPI.CheckNonTeamMemberAllocationSPWebStringSqlConnectionString
                = (_, __, ___, ____) => { };
        }
    }
}