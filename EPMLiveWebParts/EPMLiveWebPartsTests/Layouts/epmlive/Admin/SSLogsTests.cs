using System;
using System.Diagnostics.CodeAnalysis;
using EPMLiveWebParts.Layouts.epmlive.Admin;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
namespace EPMLiveWebParts.Tests.Layouts.epmlive.Admin
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SSLogsTests
    {
        private IDisposable _shimsObject;
        private SSLogs _testObj;
        private PrivateObject _privateObj;
        private const string UtcMinus5 = "(UTC-05:00) Eastern Time (US and Canada)";
        private const string Utc2 = "(UTC+02:00) Cairo";
        private const string Utc = "(UTC+00:00) Casablanca";
        private const string ExpectedResultFromUTcMinus5 = @"{""id"":""Eastern Standard Time"",""displayName"":""(UTC-05:00) Eastern Time (US \u0026 Canada)"",""olsonName"":""America/New_York"",""standardName"":""Eastern Standard Time"",""daylightName"":""Eastern Daylight Time"",""baseUtcOffset"":{""Ticks"":-180000000000,""Days"":0,""Hours"":-5,""Milliseconds"":0,""Minutes"":0,""Seconds"":0,""TotalDays"":-0.20833333333333331,""TotalHours"":-5,""TotalMilliseconds"":-18000000,""TotalMinutes"":-300,""TotalSeconds"":-18000},""supportsDaylightSavingTime"":true}";
        private const string ExpectedResultFromUTc2 = @"{""id"":""Egypt Standard Time"",""displayName"":""(UTC+02:00) Cairo"",""olsonName"":""Africa/Cairo"",""standardName"":""Egypt Standard Time"",""daylightName"":""Egypt Daylight Time"",""baseUtcOffset"":{""Ticks"":72000000000,""Days"":0,""Hours"":2,""Milliseconds"":0,""Minutes"":0,""Seconds"":0,""TotalDays"":0.083333333333333329,""TotalHours"":2,""TotalMilliseconds"":7200000,""TotalMinutes"":120,""TotalSeconds"":7200},""supportsDaylightSavingTime"":true}";
        private const string ExpectedResultFromUTc = @"{""id"":""Morocco Standard Time"",""displayName"":""(UTC+00:00) Casablanca"",""olsonName"":""Africa/Casablanca"",""standardName"":""Morocco Standard Time"",""daylightName"":""Morocco Daylight Time"",""baseUtcOffset"":{""Ticks"":0,""Days"":0,""Hours"":0,""Milliseconds"":0,""Minutes"":0,""Seconds"":0,""TotalDays"":0,""TotalHours"":0,""TotalMilliseconds"":0,""TotalMinutes"":0,""TotalSeconds"":0},""supportsDaylightSavingTime"":true}";
        private const string SetTimeZone = "SetTimeZone";

        [TestInitialize]
        public void SetUp()
        {
            _shimsObject = ShimsContext.Create();
            _testObj = new SSLogs();
            _privateObj = new PrivateObject(_testObj);
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsObject?.Dispose();
        }

        [TestMethod]
        public void SetTimeZone_TimeZoneDescriptionUtcMinus5_ReturnsStringCurrentUserTimeZone()
        {
            // Arrange
            var user = new ShimSPUser();
            var web = new ShimSPWeb();
            var regionalSetting = new ShimSPRegionalSettings();
            var timeZone = new ShimSPTimeZone
            {
                DescriptionGet = () => UtcMinus5
            };
            regionalSetting.TimeZoneGet = () => timeZone;
            user.RegionalSettingsGet = () => regionalSetting;
            web.CurrentUserGet = () => user;
            var context = new ShimSPContext();

            // Act
            _privateObj.Invoke(SetTimeZone, web.Instance, context.Instance);

            // Assert
            var actualResult = _testObj.CurrentUserTimeZone;
            actualResult.ShouldBe(ExpectedResultFromUTcMinus5);
        }

        [TestMethod]
        public void SetTimeZone_TimeZoneDescriptionUtc2_ReturnsStringCurrentUserTimeZone()
        {
            // Arrange
            var user = new ShimSPUser();
            var web = new ShimSPWeb();
            var regionalSetting = new ShimSPRegionalSettings();
            var timeZone = new ShimSPTimeZone
            {
                DescriptionGet = () => Utc2
            };
            regionalSetting.TimeZoneGet = () => timeZone;
            user.RegionalSettingsGet = () => regionalSetting;
            web.CurrentUserGet = () => user;
            var context = new ShimSPContext();

            // Act
            _privateObj.Invoke(SetTimeZone, web.Instance, context.Instance);

            // Assert
            var actualResult = _testObj.CurrentUserTimeZone;
            actualResult.ShouldBe(ExpectedResultFromUTc2);
        }

        [TestMethod]
        public void SetTimeZoneUtc_TimeZoneDescription_ReturnsStringCurrentUserTimeZone()
        {
            // Arrange
            var user = new ShimSPUser();
            var web = new ShimSPWeb();
            var regionalSetting = new ShimSPRegionalSettings();
            var timeZone = new ShimSPTimeZone
            {
                DescriptionGet = () => Utc
            };
            regionalSetting.TimeZoneGet = () => timeZone;
            user.RegionalSettingsGet = () => regionalSetting;
            web.CurrentUserGet = () => user;
            var context = new ShimSPContext();

            // Act
            _privateObj.Invoke(SetTimeZone, web.Instance, context.Instance);

            // Assert
            var actualResult = _testObj.CurrentUserTimeZone;
            actualResult.ShouldBe(ExpectedResultFromUTc);
        }

        [TestMethod]
        public void SetTimeZone_TimeZoneDescriptionInvalid_ReturnsStringCurrentUserTimeZone()
        {
            // Arrange
            var user = new ShimSPUser();
            var web = new ShimSPWeb();
            var regionalSetting = new ShimSPRegionalSettings();
            var timeZone = new ShimSPTimeZone
            {
                DescriptionGet = () => "invalid time zone description"
            };
            regionalSetting.TimeZoneGet = () => timeZone;
            user.RegionalSettingsGet = () => regionalSetting;
            web.CurrentUserGet = () => user;
            var context = new ShimSPContext();

            // Act
            _privateObj.Invoke(SetTimeZone, web.Instance, context.Instance);

            // Assert
            var actualResult = _testObj.CurrentUserTimeZone;
            actualResult.ShouldBe("null");
        }
    }
}