using System;
using System.Data.SqlClient.Fakes;
using System.Fakes;
using System.Linq;
using EPMLiveTimesheets.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets.Fakes;

namespace TimeSheets.Tests
{
    [TestClass]
    public class TimesheetAPIStopStopWatchTests : SheetTestBase
    {
        private const int UserId = 23;
        private static readonly string XmlSample = $"<root ID=\"10\" UserId=\"{UserId}\"></root>";
        private static readonly DateTime NowSample = new DateTime(2018, 01, 09);

        [TestMethod]
        public void StopStopWatch_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();

            // Act
            var message = TimesheetAPI.StopStopWatch(XmlSample, _sharepointShims.WebShim);

            // Assert
            Assert.AreEqual(Resource.StopStopWatch_Called_SqlDisposed_ExpectedResult, message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataReadersDisposed.Count);
        }

        private void SetupShims()
        {
            ShimSqlDataReader.AllInstances.Read = instance => true;
            ShimSqlDataReader.AllInstances.GetInt32Int32 = (instance, num) =>
            {
                if (num == 0)
                {
                    return UserId;
                }
                else if (num == 1)
                {
                    return 71;
                }
                throw new Exception("Unexpected call to read.");
            };
            ShimSqlDataReader.AllInstances.GetDateTimeInt32 = (_, index) => new DateTime(2018, 01, 09, 0, 0, 0);

            _sharepointShims.UserShim.IDGet = () => UserId;
            ShimTimesheetAPI.GetUserSPWebString = (_, __) => _sharepointShims.UserShim;

            ShimTimesheetSettings.ConstructorSPWeb = (instance, spWeb) =>
            {
                instance.DayDef = "true|true|true|true|true|true|true|true|1";
            };

            ShimDateTime.NowGet = () => NowSample;
        }
    }
}