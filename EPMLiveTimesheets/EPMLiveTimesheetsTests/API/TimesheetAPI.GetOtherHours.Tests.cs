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
    public class TimesheetAPIGetOtherHoursTests : SheetTestBase
    {
        private const string XmlSample = "<root ID=\"10\" List=\"100\"><a></a></root>";
        private const int UserId = 23;
        private const double HoursSample = 11;

        [TestMethod]
        public void GetOtherHours_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();

            // Act
            var message = TimesheetAPI.GetOtherHours(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual("<GetOtherHours Status=\"0\">11</GetOtherHours>", message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(1, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataReadersDisposed.Count);
        }

        private void SetupShims()
        {
            ShimSqlDataReader.AllInstances.Read = instance => true;
            ShimSqlDataReader.AllInstances.GetDoubleInt32 = (instance, num) =>
            {
                if (num == 0)
                {
                    return HoursSample;
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