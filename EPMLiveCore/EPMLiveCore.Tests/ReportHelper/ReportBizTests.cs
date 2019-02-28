using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web.UI.WebControls;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.ReportHelper
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ReportBizTests
    {
        private static readonly Guid DummyGuid = Guid.NewGuid();
        private const string DummyString = "DummyString";
        private const string HasForeignKeyMethodName = "HasForeignKey";
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
            ShimReportData.ConstructorGuid = (_, guid) => { };
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
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
            ShimListBiz.CreateNewMappingGuidGuidListItemCollectionBoolean = 
                (site, list, fieldsCollection, auto) =>
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
            ShimListBiz.CreateNewMappingGuidGuidGuidListItemCollection = 
                (site, list, web, fieldsCollection) =>
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
            ShimListBiz.CreateNewMappingGuidGuidListItemCollectionBoolean = 
                (site, list, fieldsCollection, auto) =>
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
                () => expectedLogs.ForEach(p => logMessages.Any(log => log.Contains(p))));
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

        [TestMethod]
        public void UpdateForeignKeys_Should_ExecuteCorrectly()
        {
            // Arrange
            var expectedCommands = new List<string>
            {
                "BEGIN TRY " +
                "WHILE EXISTS(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME like" + 
                " 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) BEGIN DECLARE @cName nvarchar(Max) " +
                "SELECT @cName = (SELECT TOP 1 [CONSTRAINT_NAME] FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE " + 
                "WHERE CONSTRAINT_NAME LIKE 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                "DECLARE @sql nvarchar(Max) SELECT @sql = 'ALTER TABLE ' + @tableName + ' DROP CONSTRAINT ' + @cName " +
                "EXEC sp_executesql @sql END END TRY BEGIN CATCH PRINT 'Error Detected' END CATCH",

                "BEGIN TRY " +
                "WHILE EXISTS(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME like 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                "BEGIN DECLARE @cName nvarchar(Max) " +
                "SELECT @cName = (SELECT TOP 1 [CONSTRAINT_NAME] FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE CONSTRAINT_NAME LIKE 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                "DECLARE @sql nvarchar(Max) SELECT @sql = 'ALTER TABLE ' + @tableName + ' DROP CONSTRAINT ' + @cName " +
                "EXEC sp_executesql @sql END END TRY BEGIN CATCH PRINT 'Error Detected' END CATCH"
            };
            var executedCommands = new List<string>();
            var dao = new ShimEPMData
            {
                ExecuteNonQuerySqlConnection = _ => true,
                GetClientReportingConnectionGet = () => new SqlConnection(),
                Dispose = () => { },
                CommandSetString = command => executedCommands.Add(command)
            };
            ShimReportBiz.AllInstances.GetAllForeignKeysEPMData = (_, epmData) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyGuid
                        }
                    }.GetEnumerator()
                }
            };

            // Act
            var result = reportBiz.UpdateForeignKeys(dao);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => expectedCommands.All(p => executedCommands.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void AddORRemoveForeignKey_AddOperationFalse_ExecutesCorrectly()
        {
            // Arrange
            var expectedCommands = new List<string>
            {
                "BEGIN TRY " +
                "WHILE EXISTS(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME " +
                "like 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) BEGIN DECLARE @cName nvarchar(Max) " +
                "SELECT @cName = (SELECT TOP 1 [CONSTRAINT_NAME] FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE " + 
                "WHERE CONSTRAINT_NAME LIKE 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                "DECLARE @sql nvarchar(Max) SELECT @sql = 'ALTER TABLE ' + @tableName + ' DROP CONSTRAINT ' + @cName " +
                "EXEC sp_executesql @sql END END TRY BEGIN CATCH PRINT 'Error Detected' END CATCH",

                "BEGIN TRY " +
                "WHILE EXISTS(select * from INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE where CONSTRAINT_NAME like" + 
                " 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) BEGIN DECLARE @cName nvarchar(Max) " +
                "SELECT @cName = (SELECT TOP 1 [CONSTRAINT_NAME] FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE " + 
                "WHERE CONSTRAINT_NAME LIKE 'FK_EPMLIVE_%' AND TABLE_NAME=@tableName) " +
                "DECLARE @sql nvarchar(Max) SELECT @sql = 'ALTER TABLE ' + @tableName + ' DROP CONSTRAINT ' + @cName " +
                "EXEC sp_executesql @sql END END TRY BEGIN CATCH PRINT 'Error Detected' END CATCH"
            };
            var executedCommands = new List<string>();
            var dao = new ShimEPMData
            {
                ExecuteNonQuerySqlConnection = _ => true,
                GetClientReportingConnectionGet = () => new SqlConnection(),
                Dispose = () => { },
                CommandSetString = command => executedCommands.Add(command)
            };
            ShimReportBiz.AllInstances.GetAllForeignKeysEPMData = (_, epmData) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyGuid
                        }
                    }.GetEnumerator()
                }
            };
            var foreignKey = new ShimDataRow
            {
                ItemGetString = name => DummyString
            };

            // Act
            var result = reportBiz.AddORRemoveForeignKey(dao, foreignKey, false);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => expectedCommands.All(p => executedCommands.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void AddORRemoveForeignKey_AddOperation_ExecutesCorrectly()
        {
            // Arrange
            var expectedCommands = new List<string>
            {
                DummyString
            };
            var executedCommands = new List<string>();
            var dao = new ShimEPMData
            {
                ExecuteNonQuerySqlConnection = _ => true,
                GetClientReportingConnectionGet = () => new SqlConnection(),
                Dispose = () => { },
                CommandSetString = command => executedCommands.Add(command)
            };
            ShimReportBiz.AllInstances.GetAllForeignKeysEPMData = (_, epmData) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    GetEnumerator = () => new List<DataRow>
                    {
                        new ShimDataRow
                        {
                            ItemGetString = name => DummyGuid
                        }
                    }.GetEnumerator()
                }
            };
            var foreignKey = new ShimDataRow
            {
                ItemGetString = name => DummyString
            };

            // Act
            var result = reportBiz.AddORRemoveForeignKey(dao, foreignKey, true);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => expectedCommands.All(p => executedCommands.Contains(p)).ShouldBeTrue());
        }

        [TestMethod]
        public void GetReferencingTables_Should_ExecuteCorrectly()
        {
            // Arrange
            var expectedCommand = $"EXEC sp_MSdependencies N'{DummyString}', null, 1315327";
            var commandExecuted = string.Empty;
            var dao = new ShimEPMData
            {
                GetTableSqlConnection = _ => new DataTable(),
                GetClientReportingConnectionGet = () => new SqlConnection(),
                Dispose = () => { },
                CommandSetString = command => commandExecuted = command
            };

            // Act
            var result = reportBiz.GetReferencingTables(dao, DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => commandExecuted.ShouldNotBeNullOrEmpty(),
                () => commandExecuted.ShouldBe(expectedCommand));
        }

        [TestMethod]
        public void HasForeignKey_OnSuccess_ReturnsTrue()
        {
            // Arrange
            var dao = new ShimEPMData
            {
                GetClientReportingConnectionGet = () => new SqlConnection(),
                ExecuteScalarSqlConnection = _ => 1
            }.Instance;
            var args = new object[] { dao, DummyString, DummyString };

            // Act
            var result = (bool)privateObject.Invoke(HasForeignKeyMethodName, args);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void HasForeignKey_OnException_ReturnsFalse()
        {
            // Arrange
            var dao = new ShimEPMData
            {
                GetClientReportingConnectionGet = () => new SqlConnection(),
                ExecuteScalarSqlConnection = _ =>
                {
                    throw new Exception();
                }
            }.Instance;
            var args = new object[] { dao, DummyString, DummyString };

            // Act
            var result = (bool)privateObject.Invoke(HasForeignKeyMethodName, args);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void RefreshTimesheet_TimesheetDataNull_ReturnsErrorMessage()
        {
            // Arrange
            const string ExpectedMessage = "No timesheet data exists.";
            var message = string.Empty;
            var logMessages = new List<string>();
            ShimReportData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMsg, longMsg, level, type, jobGuid) =>
                {
                    logMessages.Add(shortMsg);
                    return true;
                };
            ShimReportData.AllInstances.GetTSAllDataWithSchema = _ => null;

            // Act
            var result = reportBiz.RefreshTimesheet(out message, DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => message.ShouldBe(ExpectedMessage));
        }

        [TestMethod]
        public void RefreshTimesheet_OnSuccess_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            var logMessages = new List<string>();
            var errorMessages = new List<string>
            {
                "Error occurred while inserting data into RPTTSData for web",
                "Error occured while recreating RPTTSData for web"
            };
            ShimReportData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMsg, longMsg, level, type, jobGuid) =>
                {
                    logMessages.Add(shortMsg);
                    return true;
                };
            ShimReportData.AllInstances.GetTSAllDataWithSchema = _ => new DataTable();
            ShimReportData.AllInstances.DeleteExistingTSData = _ => true;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => null
                    }
                }.GetEnumerator()
            };
            ShimReportData.AllInstances.CreateTableStringListOfColumnDefBooleanStringOut = CreateTableSuccess;
            ShimReportData.AllInstances.InsertTSAllDataDataTableStringOut = InsertTSAllDataSuccess;
            ShimReportData.AllInstances.GetSafeTableNameString = (_, name) => DummyString;

            // Act
            var result = reportBiz.RefreshTimesheet(out message, DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => errorMessages.All(p => logMessages.Any(l => l.Contains(p))).ShouldBeFalse());
        }

        [TestMethod]
        public void RefreshTimesheet_OnReportDataError_ReturnsTrue()
        {
            // Arrange
            var message = string.Empty;
            var logMessages = new List<string>();
            var errorMessages = new List<string>
            {
                "Error occurred while inserting data into RPTTSData for web",
                "Error occured while recreating RPTTSData for web"
            };
            ShimReportData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMsg, longMsg, level, type, jobGuid) =>
                {
                    logMessages.Add(shortMsg);
                    return true;
                };
            ShimReportData.AllInstances.GetTSAllDataWithSchema = _ => new DataTable();
            ShimReportData.AllInstances.DeleteExistingTSData = _ => true;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => null
                    }
                }.GetEnumerator()
            };
            ShimReportData.AllInstances.CreateTableStringListOfColumnDefBooleanStringOut = CreateTableError;
            ShimReportData.AllInstances.InsertTSAllDataDataTableStringOut = InsertTSAllDataError;
            ShimReportData.AllInstances.GetSafeTableNameString = (_, name) => DummyString;

            // Act
            var result = reportBiz.RefreshTimesheet(out message, DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => errorMessages.All(p => logMessages.Any(l => l.Contains(p))).ShouldBeTrue());
        }

        [TestMethod]
        public void RefreshTimesheet_OnException_ReturnsError()
        {
            // Arrange
            const string ExpectedMessage = "Refresh not completed due errors.";
            var message = string.Empty;
            ShimReportData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMsg, longMsg, level, type, jobGuid) =>
                {
                    throw new Exception();
                };

            // Act
            var result = reportBiz.RefreshTimesheet(out message, DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => message.ShouldContain(ExpectedMessage));
        }

        [TestMethod]
        public void GetSpecificForeignKey_Should_ExecuteCorrectly()
        {
            // Arrange
            var lookupId = Guid.NewGuid();
            var dao = new ShimEPMData
            {
                GetTableSqlConnection = _ => new DataTable(),
                GetClientReportingConnectionGet = () => new SqlConnection()
            };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid =>
                {
                    return guid == lookupId
                        ? new ShimSPList()
                        : null;
                }
            };
            ShimSPSite.AllInstances.AllWebsGet = _ =>
            {
                var list = new List<SPWeb>
                {
                    new ShimSPWeb
                    {
                        ListsGet = () => new ShimSPListCollection
                        {
                            ItemGetGuid = guid => new ShimSPList()
                        }
                    }
                }.AsEnumerable();
                return new ShimSPWebCollection().Bind(list);
            };
            ShimReportBiz.AllInstances.HasForeignKeyEPMDataStringString =
                (_, reportData, table, column) => true;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                CountGet = () => 1,
                ItemGetInt32 = index => new ShimDataRow
                {
                    ItemGetString = name => DummyString
                },
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => DummyString
                    }
                }.GetEnumerator()
            };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = name => new ShimSPFieldLookup
                {
                    LookupListGet = () => lookupId.ToString()
                }
            };
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;

            // Act
            var result = reportBiz.GetSpecificForeignKey(dao, DummyGuid.ToString(), DummyString, DummyString);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Rows.Count.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void GetAllForeignKeys_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            var lookupId = Guid.NewGuid();

            var dao = new ShimEPMData
            {
                GetClientReportingConnectionGet = () => new SqlConnection(),
                GetTableSqlConnection = _ => new ShimDataTable
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
                }
            };
            ShimDataTable.AllInstances.SelectString = (_, query) => new DataRow[]
            {
                new ShimDataRow
                {
                    ItemGetString = name => DummyString
                }
            };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = name => null,
                ItemGetGuid = guid =>
                {
                    return guid == lookupId
                        ? new ShimSPList()
                        : null;
                }
            };
            ShimSPSite.AllInstances.AllWebsGet = _ =>
            {
                var list = new List<SPWeb>
                {
                    new ShimSPWeb
                    {
                        ListsGet = () => new ShimSPListCollection
                        {
                            ItemGetGuid = guid => new ShimSPList(),
                            ItemGetString = name => new ShimSPList()
                        }
                    }
                }.AsEnumerable();
                return new ShimSPWebCollection().Bind(list);
            };
            ShimSPList.AllInstances.FieldsGet = _ => new ShimSPFieldCollection
            {
                GetFieldByInternalNameString = name =>
                {
                    return new ShimSPFieldLookup
                    {
                        LookupListGet = () => lookupId.ToString()
                    }.Instance;
                }
            };
            ShimSPField.AllInstances.TypeAsStringGet = _ => DummyString;
            ShimSPList.AllInstances.TitleGet = _ => DummyString;

            // Act
            var result = reportBiz.GetAllForeignKeys(dao);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Rows.Count.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void GetAllForeignKeys_OnException_ExecutesCorrectly()
        {
            // Arrange
            var dao = new ShimEPMData
            {
                GetClientReportingConnectionGet = () => new SqlConnection(),
                GetTableSqlConnection = _ => new ShimDataTable
                {
                    RowsGet = () =>
                    {
                        throw new Exception();
                    }
                }
            };

            // Act
            var result = reportBiz.GetAllForeignKeys(dao);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Rows.Count.ShouldBe(0));
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private bool InsertTSAllDataSuccess(
            ReportData reportData,
            DataTable table,
            out string message)
        {
            message = string.Empty;
            return true;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private bool InsertTSAllDataError(
            ReportData reportData,
            DataTable table,
            out string message)
        {
            message = DummyString;
            return false;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private bool CreateTableSuccess(
            ReportData reportData,
            string name,
            List<ColumnDef> columns,
            bool dropIfExists,
            out string message)
        {
            message = string.Empty;
            return true;
        }

        /// <summary>
        /// This is a fake method. All the parameters are required, even though not all of them are used
        /// </summary>
        private bool CreateTableError(
            ReportData reportData,
            string name,
            List<ColumnDef> columns,
            bool dropIfExists,
            out string message)
        {
            message = DummyString;
            return false;
        }
    }
}
