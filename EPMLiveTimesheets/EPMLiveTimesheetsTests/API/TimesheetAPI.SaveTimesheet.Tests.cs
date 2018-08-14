using EPMLiveCore.Fakes;
using EPMLiveTimesheets.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient.Fakes;
using System.Linq;
using TimeSheets.Fakes;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPISaveTimesheetTests : SheetTestBase
    {
        private const string XmlSample = "<root TSUID=\"10\" Rows=\"100,101\"><a></a></root>";
        private const int UserId = 23;

        [TestMethod]
        public void SaveTimesheet_Tests()
        {
            // Arrange
            SetupShims();

            // Act
            var message = TimesheetAPI.SaveTimesheet(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual("<SaveTimesheet Status=\"0\">Save Queued</SaveTimesheet>", message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(4, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(2, _adoShims.DataReadersDisposed.Count);
        }

        private void SetupShims()
        {
            ShimSqlDataReader.AllInstances.Read = instance => true;
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (instance, num) =>
            {
                if (num == 0)
                {
                    return 3;
                }
                throw new Exception("Unexpected call to read.");
            };
            ShimSqlDataReader.AllInstances.GetBooleanInt32 = (instance, num) =>
            {
                return false;
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (_, __) => true.ToString();
            ShimTimesheetAPI.CheckNonTeamMemberAllocationSPWebStringSqlConnectionString
                = (_, __, ___, ____) => { };
        }
    }
}