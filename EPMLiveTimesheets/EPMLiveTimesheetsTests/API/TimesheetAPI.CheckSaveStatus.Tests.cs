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
    public class TimesheetAPICheckSaveStatusTests : SheetTestBase
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

        [TestMethod]
        public void CheckSaveStatus_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();

            // Act
            var message = TimesheetAPI.CheckSaveStatus(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual(
                "<SaveStatus Result=\"0\" Status=\"5\" PercentComplete=\"7\" ErrorResult=\"result-sample\"" +
                " ResultText=\"result-text-sample\"></SaveStatus>",
                message);
            //Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            //Assert.AreEqual(1, _adoShims.CommandsDisposed.Count);
            //Assert.AreEqual(1, _adoShims.DataReadersDisposed.Count);
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
        }
    }
}