using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Fakes;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using EPMLiveCore.Fakes;
using EPMLiveCore.ReportHelper;
using EPMLiveCore.ReportHelper.Fakes;
using EPMLiveReportsAdmin;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveReporting.Tests
{
    [TestClass]
    public class DataScrubberTests
    {
        private const string DummyString = "DummyString";
        private const string DummyUrl = "https://www.dummy.org/url";
        private const string ParentItemKey = "ParentItem";
        private readonly Guid DummyGuid = Guid.NewGuid();
        private IDisposable shimContext;
        private static SPSite spSite;
        private static EPMData epmData;

        [TestInitialize]
        public void Initialize()
        {
            shimContext = ShimsContext.Create();
            SetupShims();
            spSite = new ShimSPSite();
            epmData = new ShimEPMData();
        }

        private void SetupShims()
        {
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimDbDataAdapter.AllInstances.FillDataTable = (_, dataTable) => 1;
            ShimSPSite.ConstructorGuid = (_, guid) => { };
            ShimSqlBulkCopy.ConstructorSqlConnection = (_, connection) => { };
            ShimSqlBulkCopy.ConstructorSqlConnectionSqlBulkCopyOptionsSqlTransaction = (_, connection, options, transaction) => { };
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_, dataTable) => { };
            ShimSqlBulkCopy.AllInstances.Close = _ => { };
            ShimSqlConnection.AllInstances.BeginTransaction = _ => new ShimSqlTransaction
            {
                Commit = () => { },
            };
            ShimGridGanttSettings.ConstructorSPList = (_, spList) => { };
            ShimEPMData.AllInstances.GetClientReportingConnectionGet = _ => new ShimSqlConnection();
            ShimEPMData.AllInstances.GetEPMLiveConnectionGet = _ => new ShimSqlConnection();
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (_, listId, listName, shortMsg, longMsg, level, type, guid) => true;
            ShimSqlBulkCopy.AllInstances.ColumnMappingsGet = _ => new ShimSqlBulkCopyColumnMappingCollection();
            ShimSqlBulkCopyColumnMappingCollection.AllInstances.AddStringString = (_, source, SPCopyDestination) => new SqlBulkCopyColumnMapping();
            ShimGridGanttSettings.ConstructorSPList = (_, spList) => { };
            ShimSPSite.AllInstances.IDGet = _ => DummyGuid;
            ShimSPSite.AllInstances.AllWebsGet = _ =>
            {
                var list = new List<SPWeb>
                {
                    new ShimSPWeb
                    {
                        AuthorGet = () => new ShimSPUser
                        {
                            IDGet = () => 1
                        },
                        IDGet = () => DummyGuid,
                        ServerRelativeUrlGet = () => DummyUrl,
                        TitleGet = () => DummyString,
                        AllPropertiesGet = () => new Hashtable
                        {
                            [ParentItemKey] = $"{DummyGuid}^^{DummyGuid}^^123"
                        },
                        ListsGet = () => new ShimSPListCollection
                        {
                            TryGetListString = name => new ShimSPList
                            {
                                IDGet = () => DummyGuid
                            }
                        }
                    },
                    new ShimSPWeb
                    {
                        AuthorGet = () => new ShimSPUser
                        {
                            IDGet = () => 1073741823
                        },
                        IDGet = () => DummyGuid,
                        ServerRelativeUrlGet = () => DummyUrl,
                        TitleGet = () => DummyString,
                        AllPropertiesGet = () => new Hashtable()
                    }
                }.AsEnumerable();
                return new ShimSPWebCollection().Bind(list);
            };
            ShimSPSecurableObject.AllInstances.RoleAssignmentsGet = _ =>
            {
                var list = new List<SPRoleAssignment>
                {
                    new ShimSPRoleAssignment
                    {
                        MemberGet = () => new ShimSPGroup().Instance,
                        RoleDefinitionBindingsGet = () =>
                        {
                            var bindings = new List<SPRoleDefinition>
                            {
                                new SPRoleDefinition()
                                {
                                    BasePermissions = SPBasePermissions.ViewListItems
                                }
                            }.AsEnumerable();
                            return new ShimSPRoleDefinitionBindingCollection().Bind(bindings);
                        }
                    }
                }.AsEnumerable();
                return new ShimSPRoleAssignmentCollection().Bind(list);
            };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                AddObjectArray = parameters => new ShimDataRow().Instance,
                CountGet = () => 1,
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => DummyString
                    }
                }.GetEnumerator()
            };
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimContext?.Dispose();
        }

        [TestMethod]
        public void CleanTables_Should_WipeTables()
        {
            // Arrange
            const string WipeReportListIds = "DELETE FROM ReportListIds";
            const string WipeRPTWeb = "DELETE FROM RPTWeb";
            const string WipeRPTWebGroups = "DELETE FROM RPTWEBGROUPS";
            var commandsExecuted = new List<string>();
            var site = new ShimSPSite
            {
                IDGet = () => DummyGuid
            }.Instance;
            var epmData = new ShimEPMData().Instance;
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                AddObjectArray = parameters => new ShimDataRow().Instance,
                CountGet = () => 0,
                GetEnumerator = () => new List<DataRow>().GetEnumerator()
            };
           
            ShimSqlCommand.AllInstances.ExecuteNonQuery = instance =>
            {
                commandsExecuted.Add(instance.CommandText);
                return 1;
            };

            // Act
            DataScrubber.CleanTables(site, epmData);

            // Assert
            Assert.IsTrue(commandsExecuted.Contains(WipeReportListIds));
            Assert.IsTrue(commandsExecuted.Contains(WipeRPTWeb));
            Assert.IsTrue(commandsExecuted.Contains(WipeRPTWebGroups));
        }

        [TestMethod]
        public void CleanTables_BulkInsertRPTWebGroups_ExecutsCorrectly()
        {
            // Arrange
            var destinationTable = string.Empty;
            const string ExpectedTableNAme = "dbo.RPTWEBGROUPS";
            var bulkInserted = false;
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_, dataTable) => 
            {
                if (destinationTable == ExpectedTableNAme && dataTable.Rows.Count > 0 && !bulkInserted)
                {
                    bulkInserted = true;
                }
            };
            ShimSqlBulkCopy.AllInstances.DestinationTableNameSetString = (_, name) =>
            {
                destinationTable = name;
            };

            // Act
            DataScrubber.CleanTables(spSite, epmData);

            // Assert
            Assert.IsTrue(bulkInserted);
        }

        [TestMethod]
        public void CleanTables_BulkInsertRPTWebGroupsException_LogError()
        {
            // Arrange
            const string ExpectedLogMessage = "Error while Bulk insert dbo.RPTWEBGROUPS";
            const string ExpectedTableName = "dbo.RPTWEBGROUPS";
            var destinationTable = string.Empty;
            var bulkInserted = false;
            var logMessages = new List<string>();
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_, dataTable) =>
            {
                if (destinationTable == ExpectedTableName && dataTable.Rows.Count > 0 && !bulkInserted)
                {
                    throw new Exception();
                }
            };
            ShimSqlBulkCopy.AllInstances.DestinationTableNameSetString = (_, name) =>
            {
                destinationTable = name;
            };
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (_, listId, listName, shortMsg, longMsg, level, type, guid) =>
            {
                logMessages.Add(longMsg);
                return true;
            };

            // Act
            DataScrubber.CleanTables(spSite, epmData);

            // Assert
            Assert.IsTrue(logMessages.Any(log => log.Contains(ExpectedLogMessage)));
        }

        [TestMethod]
        public void CleanTables_BulkInsertReportListIds_ExecutsCorrectly()
        {
            // Arrange
            var destinationTable = string.Empty;
            const string ExpectedTableNAme = "ReportListIds";
            var bulkInserted = false;
            var site = new ShimSPSite();
            var epmData = new ShimEPMData();
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_, dataTable) =>
            {
                if (destinationTable == ExpectedTableNAme && dataTable.Rows.Count > 0 && !bulkInserted)
                {
                    bulkInserted = true;
                }
            };
            ShimSqlBulkCopy.AllInstances.DestinationTableNameSetString = (_, name) =>
            {
                destinationTable = name;
            };

            // Act
            DataScrubber.CleanTables(site, epmData);

            // Assert
            Assert.IsTrue(bulkInserted);
        }

        [TestMethod]
        public void CleanTables_BulkInsertReportListIdsException_LogError()
        {
            // Arrange
            const string ExpectedLogMessage = "Error while bulk insert into ReportListIds";
            const string ExpectedTableName = "ReportListIds";
            var destinationTable = string.Empty;
            var bulkInserted = false;
            var logMessages = new List<string>();
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_, dataTable) =>
            {
                if (destinationTable == ExpectedTableName && dataTable.Rows.Count > 0 && !bulkInserted)
                {
                    throw new Exception();
                }
            };
            ShimSqlBulkCopy.AllInstances.DestinationTableNameSetString = (_, name) =>
            {
                destinationTable = name;
            };
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (_, listId, listName, shortMsg, longMsg, level, type, guid) =>
            {
                logMessages.Add(longMsg);
                return true;
            };

            // Act
            DataScrubber.CleanTables(spSite, epmData);

            // Assert
            Assert.IsTrue(logMessages.Any(log => log.Contains(ExpectedLogMessage)));
        }

        [TestMethod]
        public void CleanTables_BulkInsertRPTWeb_ExecutsCorrectly()
        {
            // Arrange
            var destinationTable = string.Empty;
            const string ExpectedTableNAme = "RPTWeb";
            var bulkInserted = false;
            var site = new ShimSPSite();
            var epmData = new ShimEPMData();
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_, dataTable) =>
            {
                if (destinationTable == ExpectedTableNAme && dataTable.Rows.Count > 0 && !bulkInserted)
                {
                    bulkInserted = true;
                }
            };
            ShimSqlBulkCopy.AllInstances.DestinationTableNameSetString = (_, name) =>
            {
                destinationTable = name;
            };

            // Act
            DataScrubber.CleanTables(site, epmData);

            // Assert
            Assert.IsTrue(bulkInserted);
        }

        [TestMethod]
        public void CleanTables_BulkInsertRPTWebException_LogError()
        {
            // Arrange
            const string ExpectedLogMessage = "Error while  BULK INSERT RPTWeb and epmlive.Webs TABLE";
            const string ExpectedTableName = "RPTWeb";
            var destinationTable = string.Empty;
            var bulkInserted = false;
            var logMessages = new List<string>();
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_, dataTable) =>
            {
                if (destinationTable == ExpectedTableName && dataTable.Rows.Count > 0 && !bulkInserted)
                {
                    throw new Exception();
                }
            };
            ShimSqlBulkCopy.AllInstances.DestinationTableNameSetString = (_, name) =>
            {
                destinationTable = name;
            };
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (_, listId, listName, shortMsg, longMsg, level, type, guid) =>
            {
                logMessages.Add(longMsg);
                return true;
            };

            // Act
            DataScrubber.CleanTables(spSite, epmData);

            // Assert
            Assert.IsTrue(logMessages.Any(log => log.Contains(ExpectedLogMessage)));
        }

        [TestMethod]
        public void CleanTables_BulkInsertFRF_ExecutsCorrectly()
        {
            // Arrange
            var destinationTable = string.Empty;
            const string ExpectedTableNAme = "FRF";
            var bulkInserted = false;
            var site = new ShimSPSite();
            var epmData = new ShimEPMData();
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_, dataTable) =>
            {
                if (destinationTable == ExpectedTableNAme && dataTable.Rows.Count > 0 && !bulkInserted)
                {
                    bulkInserted = true;
                }
            };
            ShimSqlBulkCopy.AllInstances.DestinationTableNameSetString = (_, name) =>
            {
                destinationTable = name;
            };

            // Act
            DataScrubber.CleanTables(site, epmData);

            // Assert
            Assert.IsTrue(bulkInserted);
        }

        [TestMethod]
        public void CleanTables_BulkInsertFRFException_LogError()
        {
            // Arrange
            const string ExpectedLogMessage = "Error cleaning lst tables. Error";
            const string ExpectedTableName = "FRF";
            var destinationTable = string.Empty;
            var bulkInserted = false;
            var logMessages = new List<string>();
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_, dataTable) =>
            {
                if (destinationTable == ExpectedTableName && dataTable.Rows.Count > 0 && !bulkInserted)
                {
                    throw new Exception();
                }
            };
            ShimSqlBulkCopy.AllInstances.DestinationTableNameSetString = (_, name) =>
            {
                destinationTable = name;
            };
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String = (_, listId, listName, shortMsg, longMsg, level, type, guid) =>
            {
                logMessages.Add(shortMsg);
                logMessages.Add(longMsg);
                return true;
            };

            // Act
            DataScrubber.CleanTables(spSite, epmData);

            // Assert
            Assert.IsTrue(logMessages.Any(log => log.Contains(ExpectedLogMessage)));
        }

        [TestMethod]
        public void CleanTables_Invoke_VerifyMemoryLeak()
        {
            // Arrange
            var sqlCommandConstructorInvoked = 0;
            var sqlCommandDisposeCalled = 0;
            var destinationTable = string.Empty;
            const string ExpectedTableNAme = "ReportListIds";
            var bulkInserted = false;
            var site = new ShimSPSite();
            var epmData = new ShimEPMData();
            ShimSqlBulkCopy.AllInstances.WriteToServerDataTable = (_, dataTable) =>
            {
                if (destinationTable == ExpectedTableNAme && dataTable.Rows.Count > 0 && !bulkInserted)
                {
                    bulkInserted = true;
                }
            };
            ShimSqlBulkCopy.AllInstances.DestinationTableNameSetString = (_, name) => destinationTable = name;

            ShimSqlCommand.ConstructorStringSqlConnection = (command, s, arg3) => sqlCommandConstructorInvoked++;

            ShimComponent.AllInstances.Dispose = component =>
            {
                if (component is SqlCommand)
                {
                    sqlCommandDisposeCalled++;
                }
            };

            // Act
            DataScrubber.CleanTables(site, epmData);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => sqlCommandConstructorInvoked.ShouldBeGreaterThanOrEqualTo(7),
                () => sqlCommandDisposeCalled.ShouldBeGreaterThanOrEqualTo(7),
                () => sqlCommandDisposeCalled.ShouldBe(sqlCommandConstructorInvoked));
        }
    }
}
