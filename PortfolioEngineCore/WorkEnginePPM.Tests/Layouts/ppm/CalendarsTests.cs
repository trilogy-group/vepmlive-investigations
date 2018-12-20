using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.Specialized.Fakes;
using System.Data;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Web;
using System.Web.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortfolioEngineCore;
using PortfolioEngineCore.Fakes;
using Shouldly;

namespace WorkEnginePPM.Tests.Layouts.ppm
{
    [TestClass, ExcludeFromCodeCoverage]
    public class CalendarsTests
    {
        private IDisposable _shimsContext;
        private PrivateType _privateType;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _privateType = new PrivateType(typeof(Calendars));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void UpdateCalendarInfo_Always_ReturnEmpty()
        {
            // Arrange
            HttpContext httpContext;
            CStruct cStruct;
            ArrangeForUpdateCalendarInfo(
                out httpContext,
                out cStruct);

            // Act
            var result = _privateType.InvokeStatic("UpdateCalendarInfo", httpContext, cStruct) as string;

            // Assert
            result.ShouldBeEmpty();
        }

        [TestMethod]
        public void UpdateCalendarInfo_Always_ReturnError()
        {
            // Arrange
            HttpContext httpContext;
            CStruct cStruct;
            ArrangeForUpdateCalendarInfo(
                out httpContext,
                out cStruct);
            ShimdbaCalendars.CheckPeriodsDataTableStringOut =
                (DataTable dataTable, out string reply) =>
                {
                    reply = string.Empty;
                    return StatusEnum.rsProjectNotFound;
                };

            // Act
            var result = _privateType.InvokeStatic("UpdateCalendarInfo", httpContext, cStruct) as string;

            // Assert
            result.ShouldBe("<error><severity>error</severity><location>Calendars.CheckPeriods</location><message>&lt;error&gt;&lt;severity&gt;exception&lt;/severity&gt;&lt;location&gt;Calendars.CheckPeriods&lt;/location&gt;&lt;message&gt;Saving Calendar 'name' failed&lt;/message&gt;&lt;trace&gt;&lt;/trace&gt;&lt;/error&gt;</message><trace></trace></error>");
        }

        [TestMethod]
        public void UpdateCalendarInfo_Always_ReturnExpectedStatusError()
        {
            // Arrange
            HttpContext httpContext;
            CStruct cStruct;
            ArrangeForUpdateCalendarInfo(
                out httpContext,
                out cStruct);
            ShimdbaCalendars.InsertPeriodsDBAccessInt32DataTableInt32Out =
                (DBAccess dbAccess, int calendar, DataTable dataTable, out int rowsAffected) =>
                {
                    rowsAffected = 0;
                    return StatusEnum.rsLookupAlreadyExists;
                };
            ShimSqlDb.AllInstances.StatusSetStatusEnum = (instance, statusEnum) =>
            {
                if (statusEnum == StatusEnum.rsRequestCannotBeCompleted)
                {
                    throw new InvalidOperationException("DummyException");
                }
            };

            // Act
            var result = _privateType.InvokeStatic("UpdateCalendarInfo", httpContext, cStruct) as string;

            // Assert
            result.ShouldBe("<error><severity>exception</severity><location>Calendars.UpdateCalendarInfo</location><message>Saving Calendar 'name' failed.\nDummyException</message><trace></trace></error>");
        }

        [TestMethod]
        public void UpdateCalendarInfo_Always_ReturnExpectedCStructError()
        {
            // Arrange
            HttpContext httpContext;
            CStruct cStruct;
            ArrangeForUpdateCalendarInfo(
                out httpContext,
                out cStruct);
            ShimdbaGeneral.SelectAdminDBAccessDataTableOut = (DBAccess dba, out DataTable dt) =>
            {
                dt = new DataTable
                {
                    Columns = { "ADM_PORT_COMMITMENTS_CB_ID" },
                    Rows = { new object[] { 1 } }
                };
                return StatusEnum.rsSuccess;
            };
            ShimSqlDb.AllInstances.StatusSetStatusEnum = (instance, statusEnum) =>
            {
                if (statusEnum == StatusEnum.rsRequestCannotBeCompleted)
                {
                    throw new InvalidOperationException("DummyException");
                }
            };
            ShimSqlDb.AllInstances.StatusGet = instance => StatusEnum.rsSuccess;
            ShimAdminFunctions.CalcCategoryRatesDBAccessStringOut = (DBAccess dba, out string sReply) =>
            {
                sReply = string.Empty;
                return false;
            };

            // Act
            var result = _privateType.InvokeStatic("UpdateCalendarInfo", httpContext, cStruct) as string;

            // Assert
            result.ShouldBe("<error><severity>exception</severity><location>Calendars.UpdateCalendarInfo</location><message>Saving Calendar 'name' failed to execute follow up calculations.\nDummyException</message><trace></trace></error>");
        }

        [TestMethod]
        public void UpdateCalendarInfo_Always_ReturnExpectedValue()
        {
            // Arrange
            HttpContext httpContext;
            CStruct cStruct;
            ArrangeForUpdateCalendarInfo(
                out httpContext,
                out cStruct);
            ShimSqlDb.AllInstances.StatusGet = instance => StatusEnum.rsSuccess;
            ShimdbaCalendars.UpdateCalendarDBAccessInt32RefStringStringStringOut = (DBAccess _1, ref int _2, string _3, string _4, out string reply) =>
            {
                reply = string.Empty;
                return StatusEnum.rsPIResourceCalendarNotSet;
            };

            // Act
            var result = _privateType.InvokeStatic("UpdateCalendarInfo", httpContext, cStruct) as string;

            // Assert
            result.ShouldBe(@"<calendar calendarid=""-1"" name=""name"" />");
        }

        private void ArrangeForUpdateCalendarInfo(
            out HttpContext httpContext,
            out CStruct cStruct)
        {
            httpContext = new ShimHttpContext
            {
                RequestGet = () => new ShimHttpRequest
                {
                    UrlGet = () => new Uri("http://www.url.com:8080")
                }
            };
            cStruct = new CStruct();
            cStruct.LoadXML(@"<data calendarid=""-1"" name=""name""></data>");
            var spWeb = new ShimSPWeb
            {
                PropertiesGet = () =>
                {
                    var stringDictionary = new StringDictionary
                    {
                        ["epkbasepath"] = "epkbasepath",
                        ["ppmpid"] = "ppmpid",
                        ["ppmcompany"] = "ppmcompany",
                        ["ppmdbconn"] = "ppmdbconn",
                    };
                    var shim = new ShimSPPropertyBag();
                    new ShimStringDictionary(shim)
                    {
                        ContainsKeyString = stringKey => stringDictionary.ContainsKey(stringKey),
                        ItemGetString = stringKey => stringDictionary.ContainsKey(stringKey)
                            ? stringDictionary[stringKey]
                            : null
                    };
                    return shim;
                },
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => Guid.Empty,
                    WebApplicationGet = () => new ShimSPWebApplication
                    {
                        ApplicationPoolGet = () =>
                        {
                            var shim = new ShimSPApplicationPool();
                            new ShimSPProcessIdentity(shim)
                            {
                                UsernameGet = () => "username"
                            };
                            return shim;
                        }
                    }
                }
            };
            ShimSPContext.CurrentGet = () => new ShimSPContext
            {
                WebGet = () => spWeb
            };
            ShimSPSite.ConstructorGuid = (instance, guid) => new ShimSPSite(instance)
            {
                RootWebGet = () => spWeb
            };
            ShimSqlConnection.AllInstances.Open = instance => { };
            ShimSqlConnection.AllInstances.Close = instance => { };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance => 0;
            ShimSqlCommand.AllInstances.ExecuteReader = instance => new ShimSqlDataReader
            {
                Read = () => false
            };
            ShimSqlConnection.AllInstances.BeginTransaction = sqlConnection => new ShimSqlTransaction
            {
                Commit = () => { },
                Rollback = () => { }
            };
            ShimCStruct.AllInstances.GetSubStructString = (instance, stringValue) => new ShimCStruct();
            ShimCStruct.AllInstances.GetListString = (instance, stringValue) => new List<CStruct>();
        }
    }
}
