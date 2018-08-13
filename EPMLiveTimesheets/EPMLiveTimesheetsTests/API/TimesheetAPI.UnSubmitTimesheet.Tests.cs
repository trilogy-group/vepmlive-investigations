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

        [TestMethod()]
        public void UnSubmitTimesheet_Blocked_MessageFilled()
        {
            UnSubmitTimesheet(true, -1, false);
        }

        [TestMethod()]
        public void UnSubmitTimesheet_NonBlockedApproval1NonDisableApprovals_MessageFilled()
        {
            UnSubmitTimesheet(false, 1, false);
        }

        [TestMethod()]
        public void UnSubmitTimesheet_NonBlockedApproval1DisableApprovals_MessageFilled()
        {
            UnSubmitTimesheet(false, -1, true);
        }

        public void UnSubmitTimesheet(bool blocked, int approval, bool disableApprovals)
        {
            // Arrange
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

            // Act
            var message = TimesheetAPI.UnSubmitTimesheet(XmlSample, _sharepointShims.WebShim);

            // Assert
            if (blocked)
            {
                Assert.AreEqual("<UnSubmitTimesheet Status=\"4\">That timesheet is locked.</UnSubmitTimesheet>", message);
            }
            else if (!blocked)
            {
                if (approval == 1 && !disableApprovals)
                {
                    Assert.AreEqual(
                        "<UnSubmitTimesheet Status=\"3\">That timesheet has already been approved.</UnSubmitTimesheet>",
                        message);
                }
                else
                {
                    Assert.AreEqual("<UnSubmitTimesheet Status=\"0\"></UnSubmitTimesheet>", message);
                }
            }
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            if (!blocked && disableApprovals)
            {
                Assert.AreEqual(3, _adoShims.CommandsDisposed.Count);
            }
            else
            {
                Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            }
            Assert.AreEqual(2, _adoShims.DataReadersDisposed.Count);
        }
    }
}