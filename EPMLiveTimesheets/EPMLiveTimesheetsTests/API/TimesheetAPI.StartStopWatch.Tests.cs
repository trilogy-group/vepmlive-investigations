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
    public class TimesheetAPIStartStopWatchTests: SheetTestBase
    {
        private const int UserId = 23;
        private static readonly string XmlSample = $"<root ID=\"10\" UserId=\"{UserId}\"></root>";
        private static readonly DateTime NowSample = new DateTime(2018, 01, 10);

        [TestMethod]
        public void StartStopWatch_Called_SqlDisposed()
        {
            // Arrange
            SetupShims();

            // Act
            var message = TimesheetAPI.StartStopWatch(XmlSample, _sharepointShims.WebShim);

            // Assert
            var expectedMessage = string.Format("<StopWatch Status=\"0\">{0}</StopWatch>", NowSample.ToString("F"));
            Assert.AreEqual(expectedMessage, message);
            Assert.IsTrue(_adoShims.ConnectionsDisposed.Any());
            Assert.AreEqual(2, _adoShims.CommandsDisposed.Count);
            Assert.AreEqual(1, _adoShims.DataReadersDisposed.Count);
        }

        private void SetupShims()
        {
            ShimSqlDataReader.AllInstances.Read = instance => false;
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

            _sharepointShims.UserShim.IDGet = () => UserId;
            ShimTimesheetAPI.GetUserSPWebString = (_, __) => _sharepointShims.UserShim;

            ShimTimesheetSettings.ConstructorSPWeb = (instance, spWeb) => { };

            ShimDateTime.NowGet = () => NowSample;
        }
    }
}