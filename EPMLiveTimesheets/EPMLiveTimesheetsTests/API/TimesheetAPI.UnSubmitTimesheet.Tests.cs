using System;
using System.Data.SqlClient.Fakes;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets.Fakes;

namespace TimeSheets.Tests
{
    public partial class TimesheetAPITests
    {
        private const string XmlSample = "<root ID=\"10\"><child ID=\"11\"></child></root>";
        private const int UserId = 23;

        [TestMethod]
        public void UnSubmitTimesheet_Blocked_MessageFilled()
        {
            // Arrange
            SetupShims(true, -1, false);

            // Act
            var message = TimesheetAPI.UnSubmitTimesheet(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual("<UnSubmitTimesheet Status=\"4\">That timesheet is locked.</UnSubmitTimesheet>", message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(2, _adoShims.DataReadersDisposed.Count);
        }

        [TestMethod]
        public void UnSubmitTimesheet_NonBlockedApproval1NonDisableApprovals_MessageFilled()
        {
            // Arrange
            SetupShims(false, 1, false);

            // Act
            var message = TimesheetAPI.UnSubmitTimesheet(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual(
                "<UnSubmitTimesheet Status=\"3\">That timesheet has already been approved.</UnSubmitTimesheet>",
                message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(2, _adoShims.DataReadersDisposed.Count);
        }

        [TestMethod]
        public void UnSubmitTimesheet_NonBlockedApproval1DisableApprovals_MessageFilled()
        {
            // Arrange
            SetupShims(false, -1, true);

            // Act
            var message = TimesheetAPI.UnSubmitTimesheet(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual("<UnSubmitTimesheet Status=\"0\"></UnSubmitTimesheet>", message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(3, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(2, _adoShims.DataReadersDisposed.Count);
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