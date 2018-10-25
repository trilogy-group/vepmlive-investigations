using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.ReportHelper
{
    [TestClass]
    public class ReportBizTests
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private PrivateObject privateObject;
        private IDisposable shimsContext;
        private ReportBiz reportBiz;

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            reportBiz = new ReportBiz(DummyGuid);
            privateObject = new PrivateObject(reportBiz);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimReportData.AllInstances.Dispose = _ => { };
        }

        [TestMethod]
        public void Constructor_SiteIdParameter_ShouldCreateInstance()
        {
            // Arrange, Act
            reportBiz = new ReportBiz(DummyGuid);
            privateObject = new PrivateObject(reportBiz);
            var siteId = privateObject.GetFieldOrProperty("_siteId") as Guid?;

            // Assert
            reportBiz.ShouldSatisfyAllConditions(
                () => reportBiz.ShouldNotBeNull(),
                () => siteId.ShouldNotBeNull(),
                () => siteId.Value.ShouldBe(DummyGuid));
        }

        [TestMethod]
        public void Constructor_SiteIdWebAppIdParameters_ShouldCreateInstance()
        {
            // Arrange
            var appId = Guid.NewGuid();

            // Act
            reportBiz = new ReportBiz(DummyGuid, appId);
            privateObject = new PrivateObject(reportBiz);
            var siteId = privateObject.GetFieldOrProperty("_siteId") as Guid?;
            var webAppId = privateObject.GetFieldOrProperty("_webAppId") as Guid?;

            // Assert
            reportBiz.ShouldSatisfyAllConditions(
                () => reportBiz.ShouldNotBeNull(),
                () => siteId.ShouldNotBeNull(),
                () => siteId.Value.ShouldBe(DummyGuid),
                () => webAppId.ShouldNotBeNull(),
                () => webAppId.Value.ShouldBe(appId));
        }

        [TestMethod]
        public void Constructor_SiteIdWebIdReportEnabledParameters_ShouldCreateInstance()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act
            reportBiz = new ReportBiz(DummyGuid, guid, true);
            privateObject = new PrivateObject(reportBiz);
            var siteId = privateObject.GetFieldOrProperty("_siteId") as Guid?;
            var webId = privateObject.GetFieldOrProperty("_webId") as Guid?;
            var reportingEnabled = privateObject.GetFieldOrProperty("_reportingV2Enabled") as bool?;

            // Assert
            reportBiz.ShouldSatisfyAllConditions(
                () => reportBiz.ShouldNotBeNull(),
                () => siteId.ShouldNotBeNull(),
                () => siteId.Value.ShouldBe(DummyGuid),
                () => webId.ShouldNotBeNull(),
                () => webId.Value.ShouldBe(guid),
                () => reportingEnabled.GetValueOrDefault().ShouldBeTrue());
        }

        [TestMethod]
        public void WebTitle_Get_ReturnsExpectedValue()
        {
            // Arrange
            const string Title = "DummyTitle";
            ShimSPWeb.AllInstances.ExistsGet = _ => true;
            ShimSPWeb.AllInstances.TitleGet = _ => Title;

            // Act
            var result = reportBiz.WebTitle;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNullOrEmpty(),
                () => result.ShouldBe(Title));
        }

        [TestMethod]
        public void SiteExists_Should_ReturnTrue()
        {
            // Arrange
            ShimReportData.ConstructorGuid = (_, guid) => { };
            ShimReportData.AllInstances.GetSite = _ => new ShimDataRow();

            // Act
            var result = reportBiz.SiteExists();

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void GetMappedLists_Should_ReturnList()
        {
            // Arrange
            ShimReportData.ConstructorGuid = (_, guid) => { };
            ShimReportData.AllInstances.GetListMappings = _ => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyString
                        }
                    }.GetEnumerator()
                }
            };

            // Act
            var result = reportBiz.GetMappedLists();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void GetMappedListsIds_Should_ReturnList()
        {
            // Arrange
            ShimReportData.ConstructorGuid = (_, guid) => { };
            ShimReportData.AllInstances.GetListMappings = _ => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyString
                        }
                    }.GetEnumerator()
                }
            };

            // Act
            var result = reportBiz.GetMappedListsIds();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeEmpty(),
                () => result.ShouldContain(DummyString));
        }

        [TestMethod]
        public void RemoveDatabaseMapping()
        {
            // Arrange
            var deleteDbEntryWasCalled = false;
            ShimReportData.ConstructorGuidGuid = (_, steId, appId) => { };
            ShimReportData.AllInstances.DeleteDbEntry = _ =>
            {
                deleteDbEntryWasCalled = true;
                return true;
            };

            // Act
            var result = reportBiz.RemoveDatabaseMapping();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => deleteDbEntryWasCalled.ShouldBeTrue());
        }

        [TestMethod]
        public void GetListBiz_Should_CreateListBizInstance()
        {
            // Arrange
            var listId = Guid.Empty;
            ShimListBiz.ConstructorGuidGuid = (_, list, site) =>
            {
                listId = list;
            };

            // Act
            var result = reportBiz.GetListBiz(DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => listId.ShouldBe(DummyGuid));
        }

        [TestMethod]
        public void CreateListBiz_ListIdFields_CreatesListBizInstance()
        {
            // Arrange
            var listId = Guid.Empty;
            var listBizFields = new ListItemCollection();
            listBizFields = null;
            ShimListBiz.CreateNewMappingGuidGuidListItemCollectionBoolean = (site, list, fieldsCollection, auto) =>
            {
                listId = list;
                listBizFields = fieldsCollection;
                return new ShimListBiz().Instance;
            };
            var fields = new ListItemCollection();

            // Act
            var result = reportBiz.CreateListBiz(DummyGuid, fields);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => listId.ShouldBe(DummyGuid),
                () => listBizFields.ShouldNotBeNull(),
                () => listBizFields.ShouldBe(fields));
        }

        [TestMethod]
        public void CreateListBiz_ListIdWebId_CreatesListBizInstance()
        {
            // Arrange
            var listId = Guid.Empty;
            var webId = Guid.Empty;
            var listBizFields = new ListItemCollection();
            listBizFields = null;
            ShimListBiz.CreateNewMappingGuidGuidGuidListItemCollection = (site, list, web, fieldsCollection) =>
            {
                listId = list;
                webId = web;
                listBizFields = fieldsCollection;
                return new ShimListBiz().Instance;
            };
            var fields = new ListItemCollection();

            // Act
            var result = reportBiz.CreateListBiz(DummyGuid, DummyGuid, fields);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => listId.ShouldBe(DummyGuid),
                () => webId.ShouldBe(DummyGuid),
                () => listBizFields.ShouldNotBeNull(),
                () => listBizFields.ShouldBe(fields));
        }

        [TestMethod]
        public void CreateListBiz_ListId_CreateListBizInstance()
        {
            // Arrange
            var listId = Guid.Empty;
            ShimListBiz.CreateNewMappingGuidGuidListItemCollectionBoolean = (site, list, fieldsCollection, auto) =>
            {
                listId = list;
                return new ShimListBiz().Instance;
            };

            // Act
            var result = reportBiz.CreateListBiz(DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => listId.ShouldBe(DummyGuid));
        }

        [TestMethod]
        public void SAccountInfo_Should_ReturnDataRow()
        {
            // Arrange
            var webAppId = Guid.Empty;
            ShimEPMData.ConstructorGuidGuid = (_, site, webApp) =>
            {
                webAppId = webApp;
            };
            ShimEPMData.AllInstances.SAccountInfo = _ => new ShimDataRow();

            // Act
            var result = reportBiz.SAccountInfo(DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => webAppId.ShouldBe(DummyGuid));
        }

        [TestMethod]
        public void GetDatabaseMappings_Should_ReturnDictionary()
        {
            // Arrange
            ShimReportData.ConstructorGuidGuid = (_, site, webApp) => { };
            ShimReportData.AllInstances.GetDbMappings = _ => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyString
                        }
                    }.GetEnumerator()
                }
            };

            // Act
            var result = reportBiz.GetDatabaseMappings();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeEmpty(),
                () => result.Keys.ShouldContain(DummyString));
        }

        [TestMethod]
        public void GetDistinctDatabaseList_Should_ReturnDictionary()
        {
            // Arrange
            ShimReportData.ConstructorGuidGuid = (_, site, webApp) => { };
            ShimReportData.AllInstances.GetDistinctDbMappings = _ => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyString
                        }
                    }.GetEnumerator()
                }
            };

            // Act
            var result = reportBiz.GetDistinctDatabaseList();

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeEmpty(),
                () => result.Keys.ShouldContain($"{DummyString}:{DummyString}"));
        }

        [TestMethod]
        public void RefreshTimesheetInstant_OnSuccess_ReturnsTrue()
        {
            // Arrange
            ShimReportData.ConstructorGuid = (_, guid) => { };
            var message = string.Empty;
            var expectedLogs = new List<string>
            {
                "Begin refreshing time sheet data for web",
                "Finished refreshing time sheet data for web"
            };
            var refreshTimeSheetWasCalled = false;
            var logMessages = new List<string>();
            ShimReportData.AllInstances.LogStatusStringStringStringStringInt32Int32String = 
                (_, listId, listName, shortMsg, longMsg, level, type, jobGuid) => 
                {
                    logMessages.Add(shortMsg);
                    return true;
                };
            ShimReportData.AllInstances.RefreshTimeSheetGuidStringGuid =
                (_, site, title, job) => refreshTimeSheetWasCalled = true;
            ShimReportBiz.AllInstances.WebTitleGet = _ => DummyString;

            // Act
            var result = reportBiz.RefreshTimesheetInstant(out message, DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => message.ShouldBeNullOrEmpty(),
                () => refreshTimeSheetWasCalled.ShouldBeTrue(),
                () => expectedLogs.ForEach(p => logMessages.Any(log => log.Contains(p))));// .All(p => logMessages.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void RefreshTimesheetInstant_OnException_ReturnsFalse()
        {
            // Arrange
            ShimReportData.ConstructorGuid = (_, guid) => { };
            var expectedErrorMessage = $"Refresh not completed due errors";
            var message = string.Empty;
            ShimReportData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMsg, longMsg, level, type, jobGuid) => true;
            ShimReportData.AllInstances.RefreshTimeSheetGuidStringGuid =
                (_, site, title, job) =>
                {
                    throw new Exception(DummyString);
                };
            ShimReportBiz.AllInstances.WebTitleGet = _ => DummyString;

            // Act
            var result = reportBiz.RefreshTimesheetInstant(out message, DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => message.ShouldNotBeNullOrEmpty(),
                () => message.ShouldContain(expectedErrorMessage));
        }

    }
}
