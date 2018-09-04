using System;
using System.Data.SqlClient.Fakes;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets.Fakes;
using EPMLiveTimesheets.Tests;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPISubmitTimesheetTests : SheetTestBase
    {
        private const string XmlSample = "<root ID=\"10\"><child ID=\"11\"></child></root>";
        private const int UserId = 23;

        [TestMethod]
        public void SubmitTimesheet_Blocked_MessageFilled()
        {
            // Arrange
            SetupShims(true, -1, false);

            // Act
            var message = TimesheetAPI.SubmitTimesheet(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual("<SubmitTimesheet Status=\"0\"></SubmitTimesheet>", message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataReadersDisposed.Count);
        }

        private void SetupShims(bool blocked, int approval, bool disableApprovals)
        {
            ShimSqlDataReader.AllInstances.Read = instance => true;
            var readNumber = -1;
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (instance, num) =>
            {
                readNumber++;
                if (readNumber == 0)
                {
                    return UserId;
                }
                else if (readNumber == 1)
                {
                    if (num == 1)
                    {
                        return approval;
                    }
                    return UserId;
                }
                throw new Exception("Unexpected call to read.");
            };
            ShimSqlDataReader.AllInstances.GetBooleanInt32 = (instance, num) =>
            {
                return blocked;
            };
            _sharepointShims.UserShim.IDGet = () => UserId;
            ShimTimesheetAPI.GetUserSPWebString = (_, __) => _sharepointShims.UserShim;
            ShimTimesheetSettings.ConstructorSPWeb = (instance, spWeb) =>
            {
                instance.DisableApprovals = disableApprovals;
            };
        }
    }
}