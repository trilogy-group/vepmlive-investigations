using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.Fakes;
using System.Globalization;
using System.IO.Fakes;
using System.Linq;
using System.Web.UI.WebControls;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.ReportHelper
{
    public partial class EPMDataTest
    {
        private const string GetListFieldsMethodName = "GetListFields";
        private const string PopulateInstanceFromDataMethodName = "PopulateInstanceFromData";
        private const string PopulateConnectionStringsMethodName = "PopulateConnectionStrings";
        private const string GetTableMethodName = "GetTable";
        private const string GetListEventsMethodName = "GetListEvents";
        private const string UpdateListNameMethodName = "UpdateListName";
        private const string GetDbVersionMethodName = "GetDbVersion";
        private IDisposable _shimContext;
        private EPMData _EPMData;

        [TestInitialize]
        public void Initialize()
        {
            _shimContext = ShimsContext.Create();
            SetupShims();
            _EPMData = new EPMData(DummyGuid);
            _privateObject = new PrivateObject(_EPMData);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _shimContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = codeToRun => codeToRun();
            ShimEPMData.AllInstances.PopulateInstanceFromData = _ => { };
            ShimEPMData.AllInstances.PopulateConnectionStrings = _ => { };
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimCoreFunctions.getConnectionStringGuid = guid => DummyString;
            ShimSPSite.AllInstances.WebApplicationGet = _ => new ShimSPWebApplication();
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb();
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb();
            ShimSqlConnection.ConstructorString = (_, conn) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Closed;
            ShimEPMData.AllInstances.ListMappedAlreadyGuid = (_, guid) => false;
            ShimEPMData.AllInstances.ListMappedAlreadyStringGuid = (_, title, guid) => false;
            ShimEPMData.AllInstances.GetListFieldsSPList = (_, spList) => new ListItemCollection();
            ShimReportBiz.ConstructorGuidGuidBoolean = (_, listId, webId, fields) => { };
            ShimReportBiz.ConstructorGuid = (_, listId) => { };
            ShimReportBiz.AllInstances.CreateListBizGuidGuidListItemCollection =
                (_, listId, webId, fields) => new ListBiz(DummyGuid, DummyGuid);
            ShimReportBiz.AllInstances.CreateListBizGuidListItemCollection =
                (_, guid, fields) => new ListBiz(DummyGuid, DummyGuid);
            ShimReportData.ConstructorGuid = (_, guid) => { };
            ShimReportData.AllInstances.GetListMappingGuid = (_, guid) => null;
            ShimSqlConnection.AllInstances.Close = _ => { };
        }

        [TestMethod]
        public void GetSnapshotQueueStatus_ParseException_FillParameters()
        {
            // Arrange
            var status = 0;
            var listGuid = string.Empty;
            var pctComplete = 0;
            var queued = false;
            const string PercentComplete = "percentComplete";
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    ItemGetInt32 = index => new ShimDataRow
                    {
                        ItemGetString = name =>
                        {
                            if (name == PercentComplete)
                            {
                                return DummyString;
                            }
                            else
                            {
                                return 1;
                            }
                        }
                    }
                }
            };

            // Act
            _EPMData.GetSnapshotQueueStatus(out status, out listGuid, out pctComplete, out queued);

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => status.ShouldBe(1),
                () => listGuid.ShouldNotBeEmpty(),
                () => pctComplete.ShouldBe(0),
                () => queued.ShouldBeTrue());
        }

        [TestMethod]
        public void GetSnapshotQueueStatus_DataTable_FillParameters()
        {
            // Arrange
            var status = 0;
            var listGuid = string.Empty;
            var pctComplete = 0;
            var queued = false;
            const string StatusKey = "status";
            const string ListGuidKey = "listguid";
            const string PercentCompleteKey = "percentComplete";
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    ItemGetInt32 = index => new ShimDataRow
                    {
                        ItemGetString = name =>
                        {
                            switch (name)
                            {
                                case StatusKey:
                                    return 1;
                                case ListGuidKey:
                                    return Guid.NewGuid();
                                case PercentCompleteKey:
                                    return 100;
                                default:
                                    return DummyString;
                            }
                        }
                    }
                }
            };

            // Act
            _EPMData.GetSnapshotQueueStatus(out status, out listGuid, out pctComplete, out queued);

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => status.ShouldBe(1),
                () => listGuid.ShouldNotBeEmpty(),
                () => pctComplete.ShouldBe(100),
                () => queued.ShouldBeTrue());
        }

        [TestMethod]
        public void GetCleanupQueueStatus_DataTableEmpty_FillParameters()
        {
            // Arrange
            var status = 0;
            var listGuid = string.Empty;
            var pctComplete = 0;
            var queued = false;
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 0
                }
            };

            // Act
            _EPMData.GetCleanupQueueStatus(out status, out listGuid, out pctComplete, out queued);

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => status.ShouldBe(0),
                () => listGuid.ShouldBeEmpty(),
                () => pctComplete.ShouldBe(0),
                () => queued.ShouldBeFalse());
        }

        [TestMethod]
        public void GetCleanupQueueStatus_ParseException_FillParameters()
        {
            // Arrange
            var status = 0;
            var listGuid = string.Empty;
            var pctComplete = 0;
            var queued = false;
            const string PercentComplete = "percentComplete";
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    ItemGetInt32 = index => new ShimDataRow
                    {
                        ItemGetString = name =>
                        {
                            if (name == PercentComplete)
                            {
                                return DummyString;
                            }
                            else
                            {
                                return 1;
                            }
                        }
                    }
                }
            };

            // Act
            _EPMData.GetCleanupQueueStatus(out status, out listGuid, out pctComplete, out queued);

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => status.ShouldBe(1),
                () => listGuid.ShouldNotBeEmpty(),
                () => pctComplete.ShouldBe(0),
                () => queued.ShouldBeTrue());
        }

        [TestMethod]
        public void GetCleanupQueueStatus_DataTable_FillParameters()
        {
            // Arrange
            var status = 0;
            var listGuid = string.Empty;
            var pctComplete = 0;
            var queued = false;
            const string StatusKey = "status";
            const string ListGuidKey = "listguid";
            const string PercentCompleteKey = "percentComplete";
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    ItemGetInt32 = index => new ShimDataRow
                    {
                        ItemGetString = name =>
                        {
                            switch (name)
                            {
                                case StatusKey:
                                    return 1;
                                case ListGuidKey:
                                    return Guid.NewGuid();
                                case PercentCompleteKey:
                                    return 100;
                                default:
                                    return DummyString;
                            }
                        }
                    }
                }
            };

            // Act
            _EPMData.GetCleanupQueueStatus(out status, out listGuid, out pctComplete, out queued);

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => status.ShouldBe(1),
                () => listGuid.ShouldNotBeEmpty(),
                () => pctComplete.ShouldBe(100),
                () => queued.ShouldBeTrue());
        }

        [TestMethod]
        public void GetAllListIDs_Should_ReturnContent()
        {
            // Arrange
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                ListsGet = () =>
                {
                    var list = new List<SPList>
                    {
                        new ShimSPList
                        {
                            IDGet = () => DummyGuid
                        },
                        new ShimSPList
                        {
                            IDGet = () => Guid.NewGuid()
                        }
                    };
                    return new ShimSPListCollection().Bind(list);
                }
            };
            var count = 0;
            ShimEPMData.AllInstances.GetListEventsSPListStringStringListOfSPEventReceiverType =
                (_, list, assembly, className, types) =>
                {
                    if (++count == 2)
                    {
                        return new List<SPEventReceiverDefinition>();
                    }
                    else
                    {
                        return new List<SPEventReceiverDefinition>
                        {
                            new ShimSPEventReceiverDefinition()
                        };
                    }
                };

            // Act
            var result = _EPMData.GetAllListIDs();

            // Assert
            result.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void GetListNames_Should_ReturnContent()
        {
            // Arrange
            ShimSPSite.AllInstances.AllWebsGet = _ =>
            {
                var list = new List<SPWeb>
                {
                    new ShimSPWeb
                    {
                        ListsGet = () =>
                        {
                            var spList = new List<SPList>
                            {
                                new ShimSPList
                                {
                                    TitleGet = () => DummyName
                                },
                                new ShimSPList
                                {
                                    TitleGet = () => DummyString
                                }
                            };
                            return new ShimSPListCollection().Bind(spList);
                        }
                    }
                }.AsEnumerable();
                return new ShimSPWebCollection().Bind(list);
            };
            var count = 0;
            ShimEPMData.AllInstances.GetListEventsSPListStringStringListOfSPEventReceiverType =
                (_, list, assembly, className, types) =>
                {
                    if (++count == 2)
                    {
                        return new List<SPEventReceiverDefinition>();
                    }
                    else
                    {
                        return new List<SPEventReceiverDefinition>
                        {
                            new ShimSPEventReceiverDefinition()
                        };
                    }
                };

            // Act
            var result = _EPMData.GetListNames();

            // Assert
            result.ShouldNotBeEmpty();
        }

        [TestMethod]
        public void GetListEvents_Should_ReturnList()
        {
            // Arrange
            var spList = new ShimSPList
            {
                EventReceiversGet = () =>
                {
                    var list = new List<SPEventReceiverDefinition>
                    {
                        new ShimSPEventReceiverDefinition
                        {
                            AssemblyGet = () => DummyString,
                            ClassGet = () => DummyName,
                            TypeGet = () => SPEventReceiverType.AppInstalled
                        }.Instance
                    };
                    return new ShimSPEventReceiverDefinitionCollection().Bind(list).Instance;
                }
            }.Instance;
            var types = new List<SPEventReceiverType>
            {
                SPEventReceiverType.AppInstalled
            };

            // Act
            var result = _privateObject.Invoke(
                GetListEventsMethodName,
                spList,
                DummyString,
                DummyName,
                types) as List<SPEventReceiverDefinition>;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void LogStatus_OnSuccess_ReturnsTrue()
        {
            // Arrange
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) => true;

            // Act
            var result = _EPMData.LogStatus(
                DummyGuid.ToString(),
                DummyString,
                DummyName,
                DummyString,
                1,
                1,
                DummyGuid.ToString());

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void LogStatus_OnException_ReturnsFalse()
        {
            // Arrange
            var count = 0;
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) =>
            {
                if (++count == 1)
                {
                    throw new Exception();
                }
                else
                {
                    return true;
                }
            };

            // Act
            var result = _EPMData.LogStatus(
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                1,
                1,
                string.Empty);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void InitializeStatusLog_Should_AddColumnsToDataTable()
        {
            // Arrange, Act
            _EPMData.InitializeStatusLog();
            var statusLog = _EPMData.GetStatusLog();

            // Assert
            statusLog.ShouldSatisfyAllConditions(
                () => statusLog.ShouldNotBeNull(),
                () => statusLog.Columns.Count.ShouldBeGreaterThan(1));
        }

        [TestMethod]
        public void InitializeStatusLogDataTable_Should_SetDataTeble()
        {
            // Arrange
            var dataTable = new ShimDataTable().Instance;

            // Act
            _EPMData.InitializeStatusLog(dataTable);
            var statusLog = _EPMData.GetStatusLog();

            // Assert
            statusLog.ShouldSatisfyAllConditions(
                () => statusLog.ShouldNotBeNull());
        }

        [TestMethod]
        public void LogRefreshStatus_OnSuccess_ReturnsTrue()
        {
            // Arrange
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) => true;

            // Act
            var result = _EPMData.LogRefreshStatus(
                DummyGuid,
                DummyString,
                DummyGuid,
                DummyString,
                DummyString,
                1);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void GetSnapshotResults_Should_ReturnContent()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableSqlConnection =
                (_, connection) => new ShimDataTable().Instance;

            // Act
            var result = _EPMData.GetSnapshotResults(DummyGuid);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void SnapshotLists_Onsuccess_ReturnsTrue()
        {
            // Arrange
            _privateObject.SetFieldOrProperty("_sqlErrorOccurred", true);
            _privateObject.SetFieldOrProperty("_sqlError", DummyString);
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) => true;
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMsg, LongMsg, level, type, guid) => true;

            // Act
            var result = _EPMData.SnapshotLists(DummyGuid, DummyGuid, DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void SnapshotLists_OnException_ReturnsFalse()
        {
            // Arrange
            _privateObject.SetFieldOrProperty("_sqlErrorOccurred", true);
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) =>
            {
                throw new Exception();
            };
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMsg, LongMsg, level, type, guid) => true;

            // Act
            var result = _EPMData.SnapshotLists(DummyGuid, DummyGuid, DummyString);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void GetSpecificReportingDbConnection_UseSqlAccount_ReturnsConnection()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    ItemGetInt32 = index => new ShimDataRow
                    {
                        ItemGetString = name => true
                    }
                }
            };

            // Act
            var result = _EPMData.GetSpecificReportingDbConnection(DummyGuid);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetSpecificReportingDbConnection_UseSqlAccountFalse_ReturnsConnection()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    ItemGetInt32 = index => new ShimDataRow
                    {
                        ItemGetString = name => false
                    }
                }
            };

            // Act
            var result = _EPMData.GetSpecificReportingDbConnection(DummyGuid);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetSpecificReportingDbConnection_OnException_LogError()
        {
            // Arrange
            var errorLog = false;
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) =>
            {
                throw new Exception();
            };
            ShimEPMData.AllInstances.LogWindowsEventsStringStringStringBooleanInt32 =
                (_, logName, source, eventMessage, modify, eventId) =>
                {
                    errorLog = true;
                };

            // Act
            var result = _EPMData.GetSpecificReportingDbConnection(DummyGuid);

            // Assert
            errorLog.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteAllItemsDB_OnSuccess_ReturnsTrue()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableNameGuid = (_, guid) => DummyName;
            ShimEPMData.AllInstances.GetListIdStringGuid = (_, name, guid) => DummyGuid;
            ShimEPMData.AllInstances.TableExistsStringSqlConnection = (_, name, connection) => true;
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) => true;

            // Act
            var result = _EPMData.DeleteAllItemsDB(DummyString, true);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteAllItemsDB_OnException_ReturnsFalse()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableNameGuid = (_, guid) =>
            {
                throw new Exception();
            };
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMsg, LongMsg, level, type, guid) => true;
            var listNames = $"{DummyString},{DummyString}";

            // Act
            var result = _EPMData.DeleteAllItemsDB(listNames, true);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void GetTableNames_Should_ReturnContent()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable().Instance;

            // Act
            var result = _EPMData.GetTableNames(DummyName);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void TableExists_Onsuccess_ReturnsTrue()
        {
            // Arrange
            ShimEPMData.AllInstances.TableExistsStringSqlConnection = null;
            var connection = new ShimSqlConnection().Instance;
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => 1;

            // Act
            var result = _EPMData.TableExists(DummyName, connection);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void GetSafeTableName_RowsEmpty_ReturnsTableName()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableNamesString = (_, tableName) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 0
                }
            };

            // Act
            var result = _EPMData.GetSafeTableName(DummyName);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DummyName));
        }

        [TestMethod]
        public void GetSafeTableName_RowsCount_ReturnsTableName()
        {
            // Arrange
            const int TableCount = 2;
            var expectedValue = DummyName + TableCount.ToString();
            ShimEPMData.AllInstances.GetTableNamesString = (_, tableName) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1
                }
            };
            ShimEPMData.AllInstances.GetTableCount = _ => TableCount;

            // Act
            var result = _EPMData.GetSafeTableName(DummyName);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(expectedValue));
        }

        [TestMethod]
        public void GetTableCount_Should_ReturnExpectedValue()
        {
            // Arrange
            const int TableCount = 2;
            ShimEPMData.AllInstances.GetTableCount = null;
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, connection) => TableCount;

            // Act
            var result = _EPMData.GetTableCount();

            // Assert
            result.ShouldBe(TableCount);
        }

        [TestMethod]
        public void UpdateListName_OnSuccess_ReturnsTrue()
        {
            // Arrange
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) => true;

            // Act
            var result = _privateObject.Invoke(UpdateListNameMethodName, DummyGuid, DummyString) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBeTrue());
        }

        [TestMethod]
        public void GetListId_OnSuccess_ReturnsGuid()
        {
            // Arrange
            var expectedValue = Guid.NewGuid();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = name => new ShimSPList
                {
                    IDGet = () => expectedValue
                }
            };

            // Act
            var result = _EPMData.GetListId(DummyName);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(expectedValue));
        }

        [TestMethod]
        public void GetListId_OnError_ReturnsEmptyGuid()
        {
            // Arrange
            var expectedValue = Guid.NewGuid();
            ShimSPWeb.AllInstances.ListsGet = _ => null;

            // Act
            var result = _EPMData.GetListId(DummyName);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(Guid.Empty));
        }

        [TestMethod]
        public void GetListIdGuid_OnSuccess_ReturnsGuid()
        {
            // Arrange
            var expectedValue = Guid.NewGuid();
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = name => new ShimSPList
                {
                    IDGet = () => expectedValue
                }
            };

            // Act
            var result = _EPMData.GetListId(DummyName, DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(expectedValue));
        }

        [TestMethod]
        public void GetTableName_OnSuccess_ShoudlReturnTableName()
        {
            // Arrange
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, conneciton) => DummyName;

            // Act
            var result = _EPMData.GetTableName(DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DummyName));
        }

        [TestMethod]
        public void GetTableName_OnException_ReturnsNull()
        {
            // Arrange
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, conneciton) =>
            {
                throw new Exception();
            };

            // Act
            var result = _EPMData.GetTableName(DummyGuid);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeNull());
        }

        [TestMethod]
        public void GetTableNameString_OnSuccess_ShoudlReturnTableName()
        {
            // Arrange
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, conneciton) => DummyString;

            // Act
            var result = _EPMData.GetTableName(DummyName);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void GetListName_OnSuccess_ShoudlReturnTableName()
        {
            // Arrange
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, conneciton) => DummyString;

            // Act
            var result = _EPMData.GetListName(DummyName);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void RefreshTimesheets_ConsolidationDone_ReturnsExpectedValue()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuid = (_, guid) => { };
            ShimReportBiz.AllInstances.RefreshTimesheetInstantStringOutGuid = ReportBizRefreshTimeSheet;
            ShimReportBiz.AllInstances.RefreshTimesheetStringOutGuid = ReportBizRefreshTimeSheet;

            // Act
            var result = _EPMData.RefreshTimesheets(out message, DummyGuid, true);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void RefreshTimesheets_ConsolidationDoneFalse_ReturnsExpectedValue()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuid = (_, guid) => { };
            ShimReportBiz.AllInstances.RefreshTimesheetInstantStringOutGuid = ReportBizRefreshTimeSheet;
            ShimReportBiz.AllInstances.RefreshTimesheetStringOutGuid = ReportBizRefreshTimeSheet;

            // Act
            var result = _EPMData.RefreshTimesheets(out message, DummyGuid, false);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void SaveWork_ProcessAssignmentsFalse_ReturnsFalse()
        {
            // Arrange
            ShimEPMData.AllInstances.ItemHasValueSPListItemString = (_, item, valueName) => true;
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => DateTime.Now,
                ParentListGet = () => new ShimSPList
                {
                    IDGet = () => DummyGuid
                }
            };
            _privateObject.SetFieldOrProperty("_sqlError", DummyString);
            ShimReportData.AddLookUpFieldValuesStringString = (valueNAme, valueType) => DummyString;
            ShimEPMData.AllInstances.ProcessAssignmentsStringStringObjectObjectGuidGuidInt32String =
                (_, work, assigned, startDate, dueDate, listId, site, itemId, listName) => false;
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMsg, LongMsg, level, type, guid) => true;

            // Act
            var result = _EPMData.SaveWork(listItem);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void SaveWork_OnException_ReturnsFalse()
        {
            // Arrange
            ShimEPMData.AllInstances.ItemHasValueSPListItemString = (_, item, valueName) => true;
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => DateTime.Now,
                ParentListGet = () => new ShimSPList
                {
                    IDGet = () => DummyGuid
                }
            };
            _privateObject.SetFieldOrProperty("_sqlError", DummyString);
            ShimReportData.AddLookUpFieldValuesStringString = (valueNAme, valueType) => DummyString;
            ShimEPMData.AllInstances.ProcessAssignmentsStringStringObjectObjectGuidGuidInt32String =
                (_, work, assigned, startDate, dueDate, listId, site, itemId, listName) =>
                {
                    throw new Exception();
                };
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, shortMsg, LongMsg, level, type, guid) => true;

            // Act
            var result = _EPMData.SaveWork(listItem);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void ProcessAssignments_OnSuccess_ReturnsTrue()
        {
            // Arrange
            ShimEPMData.AllInstances.ProcessAssignmentsStringStringObjectObjectGuidGuidInt32String = null;
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, connection) => DummyString;

            // Act
            var result = _EPMData.ProcessAssignments(
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                DummyGuid,
                DummyGuid,
                1,
                DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void GetDbVersion_Version1_ReturnsExpectedValue()
        {
            // Arrange
            const int ExpectedValue = 2010;
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, connection) => 1;

            // Act
            var result = _privateObject.Invoke(GetDbVersionMethodName) as int?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void GetDbVersion_OtherVersion_ReturnsExpectedValue()
        {
            // Arrange
            const int ExpectedValue = 2005;
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, connection) => 10;

            // Act
            var result = _privateObject.Invoke(GetDbVersionMethodName) as int?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(ExpectedValue));
        }

        [TestMethod]
        public void MapDataBase_GetDatabaseMappingsException_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                DummyName,
                DummyName,
                DummyString,
                DummyString,
                true,
                true,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void MapDataBase_MappingsContainsSiteId_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ => new Dictionary<string, string>
            {
                [DummyGuid.ToString()] = DummyName
            };

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                DummyName,
                DummyName,
                DummyString,
                DummyString,
                true,
                true,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void MapDataBase_ServerNameDBNameEmpty_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ => new Dictionary<string, string>();

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                string.Empty,
                string.Empty,
                DummyString,
                DummyString,
                true,
                true,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void MapDataBase_CheckServerConnectionFalse_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ => new Dictionary<string, string>();
            ShimReportData.ConstructorGuidStringStringBooleanStringString =
                (_, siteId, name, server, useAccount, username, password) => { };
            ShimReportData.AllInstances.CheckServerConnection = _ => false;
            ShimReportData.AllInstances.GetError = _ => string.Empty;

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                true,
                true,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void MapDataBase_DbExistsFalse_DatabaseExistsTrue_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ => new Dictionary<string, string>();
            ShimReportData.ConstructorGuidStringStringBooleanStringString =
                (_, siteId, name, server, useAccount, username, password) => { };
            ShimReportData.AllInstances.CheckServerConnection = _ => true;
            ShimReportData.AllInstances.GetError = _ => DummyName;
            ShimReportData.AllInstances.DatabaseExists = _ => true;

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                true,
                false,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void MapDataBase_DbExistsFalse_CreateDatabaseFalse_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ => new Dictionary<string, string>();
            ShimReportData.ConstructorGuidStringStringBooleanStringString =
                (_, siteId, name, server, useAccount, username, password) => { };
            ShimReportData.AllInstances.CheckServerConnection = _ => true;
            ShimReportData.AllInstances.GetError = _ => string.Empty;
            ShimReportData.AllInstances.DatabaseExists = _ => false;
            ShimReportData.AllInstances.CreateDatabase = _ => false;

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                true,
                false,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void MapDataBase_DbExistsFalse_InitializeDatabaseFalse_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ => new Dictionary<string, string>();
            ShimReportData.ConstructorGuidStringStringBooleanStringString =
                (_, siteId, name, server, useAccount, username, password) => { };
            ShimReportData.AllInstances.CheckServerConnection = _ => true;
            ShimReportData.AllInstances.GetError = _ => string.Empty;
            ShimReportData.AllInstances.DatabaseExists = _ => false;
            ShimReportData.AllInstances.CreateDatabase = _ => true;
            ShimReportData.AllInstances.InitializeDatabase = _ => false;

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                true,
                false,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void MapDataBase_DbExists_DatabaseExistsFalse_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ => new Dictionary<string, string>();
            ShimReportData.ConstructorGuidStringStringBooleanStringString =
                (_, siteId, name, server, useAccount, username, password) => { };
            ShimReportData.AllInstances.CheckServerConnection = _ => true;
            ShimReportData.AllInstances.GetError = _ => string.Empty;
            ShimReportData.AllInstances.DatabaseExists = _ => false;

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                true,
                true,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void MapDataBase_DbExists_IsReportingDBFalse_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ => new Dictionary<string, string>();
            ShimReportData.ConstructorGuidStringStringBooleanStringString =
                (_, siteId, name, server, useAccount, username, password) => { };
            ShimReportData.AllInstances.CheckServerConnection = _ => true;
            ShimReportData.AllInstances.GetError = _ => string.Empty;
            ShimReportData.AllInstances.DatabaseExists = _ => true;
            ShimReportData.AllInstances.IsReportingDB = _ => false;

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                true,
                true,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void MapDataBase_UsernamePasswordFalse_ReturnsFalse()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ => new Dictionary<string, string>();
            ShimReportData.ConstructorGuidStringStringBooleanStringString =
                (_, siteId, name, server, useAccount, username, password) => { };
            ShimReportData.AllInstances.CheckServerConnection = _ => true;
            ShimReportData.AllInstances.GetError = _ => string.Empty;
            ShimReportData.AllInstances.DatabaseExists = _ => true;
            ShimReportData.AllInstances.IsReportingDB = _ => true;

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                DummyString,
                DummyString,
                string.Empty,
                string.Empty,
                true,
                true,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void MapDataBase_InsertDbEntryOnSuccess_ReturnsTrue()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ => new Dictionary<string, string>();
            ShimReportData.ConstructorGuidStringStringBooleanStringString =
                (_, siteId, name, server, useAccount, username, password) => { };
            ShimReportData.AllInstances.CheckServerConnection = _ => true;
            ShimReportData.AllInstances.GetError = _ => string.Empty;
            ShimReportData.AllInstances.DatabaseExists = _ => true;
            ShimReportData.AllInstances.IsReportingDB = _ => true;
            ShimReportData.AllInstances.InsertDbEntry = _ => true;
            ShimReportData.AllInstances.UserNameSetString = (_, name) => { };
            ShimReportData.AllInstances.PasswordSetString = (_, name) => { };
            ShimReportData.AllInstances.UseSqlAccountSetBoolean = (_, name) => { };
            ShimEPMData.AllInstances.DefaultListsSPWeb = (_, web) => DummyString;
            ShimEPMData.AllInstances.GrantUserDbAccess = _ => true;
            ShimEPMData.AllInstances.UpdateRPTSettingsStringInt32StringOut = UpdateRPTSettings;
            ShimEPMData.AllInstances.MapDefaultListsString = (_, lists) => true;
            ShimEPMData.AllInstances.RefreshDefaultListsString = (_, lists) => true;
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimReportData.AllInstances.Dispose = _ => { };

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                true,
                true,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void MapDataBase_OnSuccess_ReturnsTrue()
        {
            // Arrange
            var message = string.Empty;
            ShimReportBiz.ConstructorGuidGuid = (_, siteId, appId) => { };
            ShimReportBiz.AllInstances.GetDatabaseMappings = _ => new Dictionary<string, string>();
            ShimReportData.ConstructorGuidStringStringBooleanStringString =
                (_, siteId, name, server, useAccount, username, password) => { };
            ShimReportData.AllInstances.CheckServerConnection = _ => true;
            ShimReportData.AllInstances.GetError = _ => string.Empty;
            ShimReportData.AllInstances.DatabaseExists = _ => true;
            ShimReportData.AllInstances.IsReportingDB = _ => true;
            ShimReportData.AllInstances.InsertDbEntry = _ => true;
            ShimReportData.AllInstances.UserNameSetString = (_, name) => { };
            ShimReportData.AllInstances.PasswordSetString = (_, name) => { };
            ShimReportData.AllInstances.UseSqlAccountSetBoolean = (_, name) => { };
            ShimEPMData.AllInstances.DefaultListsSPWeb = (_, web) => DummyString;
            ShimEPMData.AllInstances.GrantUserDbAccess = _ => true;
            ShimEPMData.AllInstances.UpdateRPTSettingsStringInt32StringOut = UpdateRPTSettings;
            ShimEPMData.AllInstances.MapDefaultListsString = (_, lists) => true;
            ShimEPMData.AllInstances.RefreshDefaultListsString = (_, lists) => true;
            ShimSPSite.AllInstances.RootWebGet = _ => new ShimSPWeb();
            ShimReportData.AllInstances.Dispose = _ => { };

            // Act
            var result = _EPMData.MapDataBase(
                DummyGuid,
                DummyGuid,
                DummyString,
                DummyString,
                DummyString,
                DummyString,
                false,
                true,
                out message);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => message.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void ListMappedAlready_ExecuteScalar1_ReturnsTrue()
        {
            // Arrange
            ShimEPMData.AllInstances.ListMappedAlreadyGuid = null;
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, conn) => 1;

            // Act
            var result = _EPMData.ListMappedAlready(DummyGuid);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void ListMappedAlready_ExecuteScalar0_ReturnsFalse()
        {
            // Arrange
            ShimEPMData.AllInstances.ListMappedAlreadyGuid = null;
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, conn) => 0;

            // Act
            var result = _EPMData.ListMappedAlready(DummyGuid);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void ListMappedAlreadyStringGuid_ExecuteScalar1_ReturnsTrue()
        {
            // Arrange
            ShimEPMData.AllInstances.ListMappedAlreadyStringGuid = null;
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, conn) => 1;

            // Act
            var result = _EPMData.ListMappedAlready(DummyString, DummyGuid);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void ListMappedAlreadyStringGuid_ExecuteScalar0_ReturnsFalse()
        {
            // Arrange
            ShimEPMData.AllInstances.ListMappedAlreadyStringGuid = null;
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, conn) => 0;

            // Act
            var result = _EPMData.ListMappedAlready(DummyString, DummyGuid);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void UpdateRPTSettings_SqlErrorOccurred_ReturnsFalse()
        {
            // Arrange
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, conn) => 0;
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, conn) => false;
            var sResult = string.Empty;
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, message, longMessage, level, type, guid) => true;
            _privateObject.SetFieldOrProperty("_sqlError", DummyString);
            _privateObject.SetFieldOrProperty("_sqlErrorOccurred", true);

            // Act
            var result = _EPMData.UpdateRPTSettings(DummyString, 1, out sResult);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeFalse(),
                () => sResult.ShouldBe(DummyString));
        }

        [TestMethod]
        public void UpdateRPTSettings_SqlErrorOccurredFalse_ReturnsTrue()
        {
            // Arrange
            const string Success = "success";
            ShimEPMData.AllInstances.ExecuteScalarSqlConnection = (_, conn) => 1;
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, conn) => true;
            var sResult = string.Empty;
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, message, longMessage, level, type, guid) => true;

            // Act
            var result = _EPMData.UpdateRPTSettings(DummyString, 1, out sResult);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => sResult.ShouldBe(Success));
        }

        private bool UpdateRPTSettings(EPMData epmData, string workingDays, int workHours, out string sResult)
        {
            sResult = DummyString;
            return true;
        }

        private bool ReportBizRefreshTimeSheet(ReportBiz reportBiz, out string message, Guid jobUid)
        {
            message = DummyString;
            return true;
        }
    }
}
