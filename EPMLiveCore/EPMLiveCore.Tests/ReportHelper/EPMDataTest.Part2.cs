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
        public void Constrcutor_BoolGuidGuid_ShouldCreateInstance()
        {
            // Arrange
            ShimSPSite.AllInstances.OpenWebGuid = (_, guid) => new ShimSPWeb
            {
                ServerRelativeUrlGet = () => DummyUrl,
                NameGet = () => DummyName,
                IDGet = () => DummyGuid
            };

            // Act
            var instance = new EPMData(true, Guid.NewGuid(), Guid.NewGuid());

            // Assert
            instance.ShouldSatisfyAllConditions(
                () => instance.ShouldNotBeNull(),
                () => instance.SiteUrl.ShouldBe(DummyUrl),
                () => instance.SiteName.ShouldBe(DummyName));
        }

        [TestMethod]
        public void Constructor_GuidGuid_ShouldCreateInstance()
        {
            // Arrange
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb
            {
                ServerRelativeUrlGet = () => DummyUrl,
                NameGet = () => DummyName,
                IDGet = () => DummyGuid
            };

            // Act
            var instance = new EPMData(DummyGuid, DummyGuid);

            // Assert
            instance.ShouldSatisfyAllConditions(
                () => instance.ShouldNotBeNull(),
                () => instance.SiteUrl.ShouldBe(DummyUrl),
                () => instance.SiteName.ShouldBe(DummyName));
        }

        [TestMethod]
        public void Constructor_GuidGuidBool_ShoudCreateInstance()
        {
            // Arrange, Act
            var instance = new EPMData(DummyGuid, DummyGuid, true);

            // Assert
            instance.ShouldSatisfyAllConditions(
                () => instance.ShouldNotBeNull());
        }

        [TestMethod]
        public void Constrcutor_WithParameters_ShouldCreateInstance()
        {
            // Arrange
            ShimSPSite.AllInstances.OpenWeb = _ => new ShimSPWeb
            {
                IDGet = () => DummyGuid
            };

            // Act
            var instance = new EPMData(DummyGuid, DummyName, DummyName, true, DummyName, DummyName);

            // Assert
            instance.ShouldSatisfyAllConditions(
                () => instance.ShouldNotBeNull(),
                () => instance.UserName.ShouldBe(DummyName),
                () => instance.Password.ShouldBe(DummyName));
        }

        [TestMethod]
        public void GetEPMLiveConnection_ConnectionClosed_OpenConnection()
        {
            // Arrange
            var connectionState = ConnectionState.Closed;
            ShimSqlConnection.AllInstances.StateGet = _ => connectionState;
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                connectionState = ConnectionState.Open;
            };

            // Act
            var result = _EPMData.GetEPMLiveConnection;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.State.ShouldBe(ConnectionState.Open),
                () => _EPMData.EPMLiveConOpen.ShouldBeTrue());
        }

        [TestMethod]
        public void GetEPMLiveConnection_ConnectionOpened_ReturnsConnection()
        {
            // Arrange
            var connectionState = ConnectionState.Open;
            ShimSqlConnection.AllInstances.StateGet = _ => connectionState;

            // Act
            var result = _EPMData.GetEPMLiveConnection;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.State.ShouldBe(ConnectionState.Open),
                () => _EPMData.EPMLiveConOpen.ShouldBeTrue());
        }

        [TestMethod]
        public void GetEPMLiveConnection_OnException_LogMessage()
        {
            // Arrange
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Closed;
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                throw new Exception();
            };

            // Act
            var result = _EPMData.GetEPMLiveConnection;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.State.ShouldBe(ConnectionState.Closed),
                () => _EPMData.EPMLiveConOpen.ShouldBeFalse());
        }

        [TestMethod]
        public void OpenEPMLiveConnection_OnException_LogMessage()
        {
            // Arrange
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                throw new Exception();
            };

            // Act
            _EPMData.OpenEPMLiveConnection = DummyString;

            // Assert
            _EPMData.EPMLiveConOpen.ShouldBeFalse();
        }

        [TestMethod]
        public void OpenClientReportingConnection_UseSqlAccount_OpenConnection()
        {
            // Arrange
            _privateObject.SetFieldOrProperty("_databaseName", DummyName);
            var connectionState = ConnectionState.Closed;
            ShimSqlConnection.AllInstances.StateGet = _ => connectionState;
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                connectionState = ConnectionState.Open;
            };
            _EPMData.UseSqlAccount = true;

            // Act
            _EPMData.OpenClientReportingConnection = DummyString;

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => _EPMData.GetClientReportingConnection.ShouldNotBeNull(),
                () => _EPMData.GetClientReportingConnection.State.ShouldBe(ConnectionState.Open));
        }

        [TestMethod]
        public void OpenClientReportingConnection_UseSqlAccountFalse_OpenConnection()
        {
            // Arrange
            _privateObject.SetFieldOrProperty("_databaseName", DummyName);
            var connectionState = ConnectionState.Closed;
            ShimSqlConnection.AllInstances.StateGet = _ => connectionState;
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                connectionState = ConnectionState.Open;
            };
            _EPMData.UseSqlAccount = false;

            // Act
            _EPMData.OpenClientReportingConnection = DummyString;

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => _EPMData.GetClientReportingConnection.ShouldNotBeNull(),
                () => _EPMData.GetClientReportingConnection.State.ShouldBe(ConnectionState.Open));
        }

        [TestMethod]
        public void OpenClientReportingConnection_OnException_LogMessage()
        {
            // Arrange
            var messageLogged = false;
            _privateObject.SetFieldOrProperty("_databaseName", DummyName);
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                throw new Exception();
            };
            _EPMData.UseSqlAccount = false;
            ShimEPMData.AllInstances.LogWindowsEventsStringStringStringBooleanInt32 =
                (_, logName, source, eventMessage, modifyPolicy, eventId) =>
                {
                    messageLogged = true;
                };

            // Act
            _EPMData.OpenClientReportingConnection = DummyString;

            // Assert
            messageLogged.ShouldBeTrue();
        }

        [TestMethod]
        public void OpenMasterDbConnection_UseSqlAccount_OpenConnection()
        {
            // Arrange
            _privateObject.SetFieldOrProperty("_databaseName", DummyName);
            var connectionState = ConnectionState.Closed;
            ShimSqlConnection.AllInstances.StateGet = _ => connectionState;
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                connectionState = ConnectionState.Open;
            };
            _EPMData.UseSqlAccount = true;

            // Act
            _EPMData.OpenMasterDbConnection = DummyString;

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => _EPMData.GetClientReportingConnection.ShouldNotBeNull(),
                () => _EPMData.GetClientReportingConnection.State.ShouldBe(ConnectionState.Open));
        }

        [TestMethod]
        public void OpenMasterDbConnection_UseSqlAccountFalse_OpenConnection()
        {
            // Arrange
            var connectionState = ConnectionState.Closed;
            ShimSqlConnection.AllInstances.StateGet = _ => connectionState;
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                connectionState = ConnectionState.Open;
            };
            _EPMData.UseSqlAccount = false;

            // Act
            _EPMData.OpenMasterDbConnection = DummyString;

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => _EPMData.GetClientReportingConnection.ShouldNotBeNull(),
                () => _EPMData.GetClientReportingConnection.State.ShouldBe(ConnectionState.Open));
        }

        [TestMethod]
        public void OpenMasterDbConnection_OnException_LogMessage()
        {
            // Arrange
            var messageLogged = false;
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                throw new Exception();
            };
            _EPMData.UseSqlAccount = false;
            _privateObject.SetFieldOrProperty("_masterCs", DummyName);
            ShimEPMData.AllInstances.LogWindowsEventsStringStringStringBooleanInt32 =
                (_, logName, source, eventMessage, modifyPolicy, eventId) =>
                {
                    messageLogged = true;
                };

            // Act
            _EPMData.OpenMasterDbConnection = DummyString;

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => _EPMData.SqlError.ShouldNotBeEmpty(),
                () => messageLogged.ShouldBeTrue());
        }

        [TestMethod]
        public void GetClientReportingConnection_OnException_LogMessage()
        {
            // Arrange
            var messageLogged = false;
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Closed;
            ShimEPMData.AllInstances.OpenClientReportingConnectionSetString = (_, connectionString) =>
            {
                throw new Exception();
            };
            ShimEPMData.AllInstances.LogWindowsEventsStringStringStringBooleanInt32 =
                (_, logName, source, eventMessage, modifyPolicy, eventId) =>
                {
                    messageLogged = true;
                };

            // Act
            var result = _EPMData.GetClientReportingConnection;

            // Assert
            messageLogged.ShouldBeTrue();
        }

        [TestMethod]
        public void Dispose_WithOpenConnections_ShouldCloseConnection()
        {
            // Arrange
            var closed = false;
            ShimSqlConnection.AllInstances.Close = _ =>
            {
                closed = true;
            };
            ShimSqlConnection.AllInstances.StateGet = _ => ConnectionState.Open;
            _privateObject.SetFieldOrProperty("_conEPMLive", new ShimSqlConnection().Instance);
            _privateObject.SetFieldOrProperty("_conClientReporting", new ShimSqlConnection().Instance);
            _privateObject.SetFieldOrProperty("_conMaster", new ShimSqlConnection().Instance);

            // Act
            _EPMData.Dispose();

            // Assert
            closed.ShouldBeTrue();
        }

        [TestMethod]
        public void CreateTextFile_Should_SetFilePath()
        {
            // Arrange
            ShimStreamWriter.AllInstances.Close = _ => { };
            ShimFile.CreateTextString = path => new ShimStreamWriter();

            // Act
            _EPMData.CreateTextFile(DummyString);
            var filePath = _privateObject.GetFieldOrProperty("_sTextFilePath") as string;

            // Assert
            filePath.ShouldSatisfyAllConditions(
                () => filePath.ShouldNotBeNull(),
                () => filePath.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void WriteToFile_OnSucces_WriteLineOnStream()
        {
            // Arrange
            var writeLineWasCalled = false;
            ShimStreamWriter.ConstructorString = (_, path) => { };
            ShimTextWriter.AllInstances.WriteLineString = (_, text) =>
            {
                writeLineWasCalled = true;
            };
            _privateObject.SetFieldOrProperty("_sTextFilePath", DummyString);

            // Act
            _EPMData.WriteToFile(DummyString);

            // Assert
            writeLineWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void WriteToFile_OnException_TraceError()
        {
            // Arrange
            var traceWasCalled = false;
            ShimTrace.TraceErrorStringObjectArray = (format, args) =>
            {
                traceWasCalled = true;
            };
            _privateObject.SetFieldOrProperty("_sTextFilePath", string.Empty);

            // Act
            _EPMData.WriteToFile(DummyString);

            // Assert
            traceWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteWork_ItemId0_ExecuteNonQuery()
        {
            // Arrange
            var nonQueryExecuted = false;
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) =>
            {
                nonQueryExecuted = true;
                return true;
            };

            // Act
            var result = _EPMData.DeleteWork(DummyGuid, 0);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => nonQueryExecuted.ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteWork_ListItemGuid_ExecuteNonQuery()
        {
            // Arrange
            var nonQueryExecuted = false;
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) =>
            {
                nonQueryExecuted = true;
                return true;
            };

            // Act
            var result = _EPMData.DeleteWork(DummyGuid, -1);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => nonQueryExecuted.ShouldBeTrue());
        }

        [TestMethod]
        public void DeleteWork_ListItemGuidEmpty_ExecuteNonQuery()
        {
            // Arrange
            var nonQueryExecuted = false;
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) =>
            {
                nonQueryExecuted = true;
                return true;
            };

            // Act
            var result = _EPMData.DeleteWork(Guid.Empty, 0);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldBeTrue(),
                () => nonQueryExecuted.ShouldBeTrue());
        }

        [TestMethod]
        public void MapLists_OnSuccess_UpdateForeignKeys()
        {
            // Arrange
            var updateForeignKeysWasCalled = false;
            var listNames = new List<Guid>
            {
                DummyGuid
            };
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList()
            };
            ShimReportBiz.AllInstances.UpdateForeignKeysEPMData = (_, dao) =>
            {
                updateForeignKeysWasCalled = true;
                return true;
            };
            ShimEPMData.AllInstances.Dispose = _ => { };

            // Act
            var result = _EPMData.MapLists(listNames, DummyGuid);

            // Assert
            updateForeignKeysWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void MapLists_OnException_LogError()
        {
            // Arrange
            var messageLogged = false;
            var listNames = new List<Guid>
            {
                DummyGuid
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (spWeb, settings) => bool.TrueString;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList()
            };
            ShimReportBiz.AllInstances.UpdateForeignKeysEPMData = (_, dao) =>
            {
                throw new Exception();
            };
            ShimEPMData.AllInstances.LogWindowsEventsStringStringStringBooleanInt32 =
                (_, logName, source, eventMessage, modifyPolicy, eventId) =>
                {
                    messageLogged = true;
                };

            // Act
            var result = _EPMData.MapLists(listNames, DummyGuid);

            // Assert
            messageLogged.ShouldBeTrue();
        }

        [TestMethod]
        public void MapDefaultLists_OnSuccess_UpdateForeignKeys()
        {
            // Arrange
            var updateForeignKeysWasCalled = false;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetString = guid => new ShimSPList()
            };
            ShimReportBiz.AllInstances.UpdateForeignKeysEPMData = (_, dao) =>
            {
                updateForeignKeysWasCalled = true;
                return true;
            };
            ShimEPMData.AllInstances.Dispose = _ => { };

            // Act
            var result = _EPMData.MapDefaultLists(DummyName);

            // Assert
            updateForeignKeysWasCalled.ShouldBeTrue();
        }

        [TestMethod]
        public void MapDefaultLists_OnException_LogError()
        {
            // Arrange
            var messageLogged = false;
            var listNames = new List<Guid>
            {
                DummyGuid
            };
            ShimCoreFunctions.getConfigSettingSPWebString = (spWeb, settings) => bool.TrueString;
            ShimSPWeb.AllInstances.ListsGet = _ => new ShimSPListCollection
            {
                ItemGetGuid = guid => new ShimSPList()
            };
            ShimReportBiz.AllInstances.UpdateForeignKeysEPMData = (_, dao) =>
            {
                throw new Exception();
            };
            ShimEPMData.AllInstances.LogWindowsEventsStringStringStringBooleanInt32 =
                (_, logName, source, eventMessage, modifyPolicy, eventId) =>
                {
                    messageLogged = true;
                };

            // Act
            var result = _EPMData.MapDefaultLists(DummyString);

            // Assert
            messageLogged.ShouldBeTrue();
        }

        [TestMethod]
        public void SetListIcon_OnSuccess_ExecuteNonQuery()
        {
            // Arrange
            var queryExecuted = false;
            var listIcons = new Dictionary<string, string>
            {
                [DummyString] = DummyName
            };
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) =>
            {
                queryExecuted = true;
                return true;
            };

            // Act
            _EPMData.SetListIcon(listIcons);

            // Assert
            queryExecuted.ShouldBeTrue();
        }

        [TestMethod]
        public void GetListFields_OnSuccess_ReturnsList()
        {
            // Arrange
            var spList = new ShimSPList
            {
                FieldsGet = () =>
                {
                    var list = new List<SPField>
                    {
                        new ShimSPField
                        {
                            InternalNameGet = () => "contenttype",
                            TitleGet = () => DummyName,
                            IdGet = () => DummyGuid
                        },
                        new ShimSPField
                        {
                            InternalNameGet = () => "extid",
                            TitleGet = () => DummyName,
                            IdGet = () => DummyGuid
                        },
                        new ShimSPField
                        {
                            HiddenGet = () => false,
                            TypeGet = () => SPFieldType.AllDayEvent,
                            InternalNameGet = () => DummyString,
                            TitleGet = () => DummyName,
                            IdGet = () => DummyGuid
                        }
                    };
                    return new ShimSPFieldCollection().Bind(list);
                }
            }.Instance;
            ShimEPMData.AllInstances.GetListFieldsSPList = null;

            // Act
            var result = _privateObject.Invoke(GetListFieldsMethodName, spList);
            var collection = result as ListItemCollection;

            // Assert
            collection.ShouldSatisfyAllConditions(
                () => collection.ShouldNotBeNull(),
                () => collection.Count.ShouldBeGreaterThan(0));
        }

        [TestMethod]
        public void DeleteExistingTSData_TableCountZero_ShouldExecuteQuery()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableCount = _ => 0;
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) => true;

            // Act
            var result = _EPMData.DeleteExistingTSData();

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void DeleteExistingTSData_TableCountValue_ShouldExecuteQuery()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableCount = _ => 10;
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) => true;

            // Act
            var result = _EPMData.DeleteExistingTSData();

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void RefreshDefaultLists_OnSuccess_ReturnsTrue()
        {
            // Arrange
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) => true;
            ShimCoreFunctions.enqueueGuidInt32SPSite = (guid, status, site) => { };

            // Act
            var result = _EPMData.RefreshDefaultLists(DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void RefreshDefaultLists_OnException_ReturnsTrue()
        {
            // Arrange
            ShimEPMData.AllInstances.ExecuteNonQuerySqlConnection = (_, connection) =>
            {
                throw new Exception();
            };
            ShimCoreFunctions.enqueueGuidInt32SPSite = (guid, status, site) => { };
            ShimEPMData.AllInstances.LogStatusStringStringStringStringInt32Int32String =
                (_, listId, listName, message, longMessage, level, type, guid) => true;

            // Act
            var result = _EPMData.RefreshDefaultLists(DummyString);

            // Assert
            result.ShouldBeFalse();
        }

        [TestMethod]
        public void DefaultLists_Should_ReturnContent()
        {
            // Arrange
            const string Assembly =
                    "EPMLiveReportsAdmin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b90e532f481cf050";
            const string Class = "EPMLiveReportsAdmin.ListEvents";
            var rootWeb = new ShimSPWeb
            {
                ListsGet = () =>
                {
                    var list = new List<SPList>
                    {
                        new ShimSPList
                        {
                            TitleGet = () => DummyName,
                            EventReceiversGet = () =>
                            {
                                var eventList = new List<SPEventReceiverDefinition>
                                {
                                    new ShimSPEventReceiverDefinition
                                    {
                                        AssemblyGet = () => Assembly,
                                        ClassGet = () => Class,
                                    }
                                };
                                return new ShimSPEventReceiverDefinitionCollection().Bind(eventList);
                            }
                        }
                    };
                    return new ShimSPListCollection().Bind(list);
                }
            };
            _privateObject.SetFieldOrProperty("_DefaultLists", string.Empty);
            ShimCoreFunctions.getConfigSettingSPWebString = (spWeb, settings) => DummyString;

            // Act
            var result = _EPMData.DefaultLists(rootWeb);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void CheckConnection_ConnectionSuccess_ReturnsTrue()
        {
            // Arrange
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };

            // Act
            var result = EPMData.CheckConnection(DummyString);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void ExecuteScalar_OnSuccess_ReturnsValue()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteScalar = _ => DummyString;

            // Act
            var result = _EPMData.ExecuteScalar(new ShimSqlConnection()) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DummyString));
        }

        [TestMethod]
        public void ExecuteNonQuery_OnSuccess_ReturnsTrue()
        {
            // Arrange
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = _EPMData.ExecuteNonQuery(new ShimSqlConnection()) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBeTrue());
        }

        [TestMethod]
        public void ExecuteNonQuery_WithParameterCollection_OnSuccess_ReturnsTrue()
        {
            // Arrange
            var command = new ShimSqlCommand
            {
                ParametersGet = () =>
                {
                    var list = new List<SqlParameter>
                    {
                        new SqlParameter("@ContentType", "document"),
                        new SqlParameter("@Title", DummyString),
                        new SqlParameter("@FileLeafRef", DummyName)
                    };
                    return new ShimSqlParameterCollection().Bind(list);
                },
            }.Instance;
            var parameters = new ShimSqlParameterCollection
            {

            }.Instance;
            var connection = new ShimSqlConnection().Instance;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = _EPMData.ExecuteNonQuery(command, parameters, connection);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void ExecuteNonQuery_WithParameterCollectionGreaterThan2000_OnSuccess_ReturnsTrue()
        {
            // Arrange
            const string Title = "@Title";
            const string ContentType = "@ContentType";
            var command = new ShimSqlCommand
            {
                ParametersGet = () => new ShimSqlParameterCollection
                {
                    CountGet = () => 2018,
                    ItemGetString = name =>
                    {
                        if (name == Title)
                        {
                            return new SqlParameter(Title, string.Empty);
                        }
                        else if (name == ContentType)
                        {
                            return new SqlParameter(ContentType, "document");
                        }
                        else
                        {
                            return new SqlParameter();
                        }
                    },
                    GetEnumerator = () => new List<SqlParameter>
                    {
                        new SqlParameter("@ContentType", "document"),
                        new SqlParameter("@Title", DummyString),
                        new SqlParameter("@FileLeafRef", DummyName)
                    }.GetEnumerator(),
                },
                CommandTextGet = () => Title
            }.Instance;
            var parameters = new ShimSqlParameterCollection
            {

            }.Instance;
            var connection = new ShimSqlConnection().Instance;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;

            // Act
            var result = _EPMData.ExecuteNonQuery(command, parameters, connection);

            // Assert
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void GetRow_Should_ReturnDataRow()
        {
            // Arrange
            var connection = new ShimSqlConnection();
            ShimDbDataAdapter.AllInstances.FillDataTable = (_, dataTable) =>
            {
                dataTable = new ShimDataTable();
                return 1;
            };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection();
            ShimDataRowCollection.AllInstances.CountGet = _ => 1;
            ShimDataRowCollection.AllInstances.ItemGetInt32 = (_, index) => new ShimDataRow();

            // Act
            var result = _EPMData.GetRow(connection);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetTable_GetFullSchema_ReturnsDataTable()
        {
            // Arrange
            var connection = new ShimSqlConnection();
            ShimDbDataAdapter.AllInstances.FillDataTable = (_, dataTable) =>
            {
                dataTable = new ShimDataTable();
                return 1;
            };

            // Act
            var result = _EPMData.GetTable(connection, true);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetSite_DataTableRowsEmpty_ReturnsNull()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 0
                }
            };
            ShimEPMData.AllInstances.GetSite = null;

            // Act
            var result = _EPMData.GetSite();

            // Assert
            result.ShouldBeNull();
        }

        [TestMethod]
        public void GetSite_DataTableRows_ReturnsDataRow()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    ItemGetInt32 = index => new ShimDataRow()
                }
            };
            ShimEPMData.AllInstances.GetSite = null;

            // Act
            var result = _EPMData.GetSite();

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void PopulateInstanceFromData_UseSqlAccountFalse_ExecutesCorrectly()
        {
            // Arrange
            const string SAccount = "SAccount";
            ShimEPMData.AllInstances.GetSite = _ => new ShimDataRow
            {
                ItemGetString = name =>
                {
                    if (name == SAccount)
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return DummyString;
                    }
                }
            };
            ShimEPMData.AllInstances.PopulateInstanceFromData = null;

            // Act
            _privateObject.Invoke(PopulateInstanceFromDataMethodName);
            var databaseName = _privateObject.GetFieldOrProperty("_databaseName") as string;
            var databaseServer = _privateObject.GetFieldOrProperty("_databaseServer") as string;

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => _EPMData.UseSqlAccount.ShouldBeFalse(),
                () => databaseName.ShouldNotBeEmpty(),
                () => databaseServer.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void PopulateInstanceFromData_UseSqlAccount_ExecutesCorrectly()
        {
            // Arrange
            const string SAccount = "SAccount";
            ShimEPMData.AllInstances.GetSite = _ => new ShimDataRow
            {
                ItemGetString = name =>
                {
                    if (name == SAccount)
                    {
                        return true;
                    }
                    else
                    {
                        return DummyString;
                    }
                }
            };
            ShimEPMData.AllInstances.PopulateInstanceFromData = null;

            // Act
            _privateObject.Invoke(PopulateInstanceFromDataMethodName);

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => _EPMData.UseSqlAccount.ShouldBeTrue(),
                () => _EPMData.UserName.ShouldNotBeEmpty(),
                () => _EPMData.Password.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void PopulateConnectionStrings_UseSqlAcount_PopulatesFields()
        {
            // Arrange
            ShimEPMData.AllInstances.PopulateConnectionStrings = null;
            _EPMData.UseSqlAccount = true;

            // Act
            _privateObject.Invoke(PopulateConnectionStringsMethodName);

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => _EPMData.remoteCs.ShouldNotBeEmpty(),
                () => _EPMData.masterCs.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void PopulateConnectionStrings_UseSqlAcountFalse_PopulatesFields()
        {
            // Arrange
            ShimEPMData.AllInstances.PopulateConnectionStrings = null;
            _EPMData.UseSqlAccount = false;

            // Act
            _privateObject.Invoke(PopulateConnectionStringsMethodName);

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => _EPMData.remoteCs.ShouldNotBeEmpty(),
                () => _EPMData.masterCs.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void SAccountInfo_DataTableEmpty_ReturnsNull()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 0
                }
            };

            // Act
            var result = _EPMData.SAccountInfo();

            // Assert
            result.ShouldBeNull();
        }

        [TestMethod]
        public void SAccountInfo_DataTableRows_ReturnsDataRow()
        {
            // Arrange
            ShimEPMData.AllInstances.GetTableSqlConnection = (_, connection) => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    ItemGetInt32 = index => new ShimDataRow()
                }
            };

            // Act
            var result = _EPMData.SAccountInfo();

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void SAccountInfo_OnSuccess_ReturnsDataRow()
        {
            // Arrange
            ShimCoreFunctions.getConnectionStringGuid = guid => DummyString;
            ShimEPMData.GetTableSqlCommand = command => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 1,
                    ItemGetInt32 = index => new ShimDataRow().Instance
                }
            };

            // Act
            var result = EPMData.SAccountInfo(DummyGuid, DummyGuid);

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void SAccountInfo_DataTableEmpty_ReturnsDataRow()
        {
            // Arrange
            ShimCoreFunctions.getConnectionStringGuid = guid => DummyString;
            ShimEPMData.GetTableSqlCommand = command => new ShimDataTable
            {
                RowsGet = () => new ShimDataRowCollection
                {
                    CountGet = () => 0,
                }
            };

            // Act
            var result = EPMData.SAccountInfo(DummyGuid, DummyGuid);

            // Assert
            result.ShouldBeNull();
        }

        [TestMethod]
        public void SAccountInfo_OnException_ReturnsNull()
        {
            // Arrange
            ShimCoreFunctions.getConnectionStringGuid = guid => DummyString;
            ShimEPMData.GetTableSqlCommand = command =>
            {
                throw new Exception();
            };

            // Act
            var result = EPMData.SAccountInfo(DummyGuid, DummyGuid);

            // Assert
            result.ShouldBeNull();
        }

        [TestMethod]
        public void GetTable_Should_ReturnDataTable()
        {
            // Arrange
            var staticType = new PrivateType(typeof(EPMData));
            ShimDbDataAdapter.AllInstances.FillDataTable = (_, dataTable) => 1;
            var command = new ShimSqlCommand().Instance;

            // Act
            var result = staticType.InvokeStatic(GetTableMethodName, command) as DataTable;

            // Assert
            result.ShouldNotBeNull();
        }

        [TestMethod]
        public void GetCalculatedFieldValue_ResultTypeCurrency_ReturnsValue()
        {
            // Arrange
            const float Expectedvalue = 1;
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => 1
            }.Instance;
            var fields = new ShimSPFieldCalculated
            {
                CurrencyLocaleIdGet = () => CultureInfo.CurrentCulture.LCID,
                GetFieldValueAsTextObject = valueName => Expectedvalue.ToString()
            };
            ShimSPField.AllInstances.GetPropertyString = (_, name) => "currency";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyName;

            // Act
            var result = _EPMData.GetCalculatedFieldValue(listItem, fields) as float?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(Expectedvalue));
        }

        [TestMethod]
        public void GetCalculatedFieldValue_ResultTypeCurrencyEmpty_ReturnsDBNull()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => 1
            }.Instance;
            var fields = new ShimSPFieldCalculated
            {
                CurrencyLocaleIdGet = () => CultureInfo.CurrentCulture.LCID,
                GetFieldValueAsTextObject = valueName => string.Empty
            };
            ShimSPField.AllInstances.GetPropertyString = (_, name) => "currency";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyName;

            // Act
            var result = _EPMData.GetCalculatedFieldValue(listItem, fields);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DBNull.Value));
        }

        [TestMethod]
        public void GetCalculatedFieldValue_ResultTypeNumber_ReturnsValue()
        {
            // Arrange
            const float Expectedvalue = 1;
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => 1
            }.Instance;
            var fields = new ShimSPFieldCalculated
            {
                CurrencyLocaleIdGet = () => CultureInfo.CurrentCulture.LCID,
                GetFieldValueAsTextObject = valueName => Expectedvalue.ToString()
            };
            ShimSPField.AllInstances.GetPropertyString = (_, name) => "number";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyName;

            // Act
            var result = _EPMData.GetCalculatedFieldValue(listItem, fields) as float?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBe(Expectedvalue));
        }

        [TestMethod]
        public void GetCalculatedFieldValue_ResultTypeNumberEmpty_ReturnsDBNull()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => 1
            }.Instance;
            var fields = new ShimSPFieldCalculated
            {
                CurrencyLocaleIdGet = () => CultureInfo.CurrentCulture.LCID,
                GetFieldValueAsTextObject = valueName => string.Empty
            };
            ShimSPField.AllInstances.GetPropertyString = (_, name) => "number";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyName;

            // Act
            var result = _EPMData.GetCalculatedFieldValue(listItem, fields);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DBNull.Value));
        }

        [TestMethod]
        public void GetCalculatedFieldValue_ResultTypeDateTime_ReturnsValue()
        {
            // Arrange
            const double Expectedvalue = 1;
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => 1
            }.Instance;
            var fields = new ShimSPFieldCalculated
            {
                CurrencyLocaleIdGet = () => CultureInfo.CurrentCulture.LCID,
                GetFieldValueAsTextObject = valueName => DateTime.Now.ToString()
            };
            ShimSPField.AllInstances.GetPropertyString = (_, name) => "datetime";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyName;

            // Act
            var result = _EPMData.GetCalculatedFieldValue(listItem, fields) as DateTime?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull());
        }

        [TestMethod]
        public void GetCalculatedFieldValue_ResultTypeDateTimeExpcetion_ReturnsDBNull()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => 1
            }.Instance;
            var fields = new ShimSPFieldCalculated
            {
                CurrencyLocaleIdGet = () => CultureInfo.CurrentCulture.LCID,
                GetFieldValueAsTextObject = valueName => DummyString
            };
            ShimSPField.AllInstances.GetPropertyString = (_, name) => "datetime";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyName;

            // Act
            var result = _EPMData.GetCalculatedFieldValue(listItem, fields);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DBNull.Value));
        }

        [TestMethod]
        public void GetCalculatedFieldValue_ResultTypeBoolean_ReturnsValue()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => 1
            }.Instance;
            var fields = new ShimSPFieldCalculated
            {
                CurrencyLocaleIdGet = () => CultureInfo.CurrentCulture.LCID,
                GetFieldValueAsTextObject = valueName => bool.TrueString
            };
            ShimSPField.AllInstances.GetPropertyString = (_, name) => "boolean";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyName;

            // Act
            var result = _EPMData.GetCalculatedFieldValue(listItem, fields) as bool?;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.Value.ShouldBeTrue());
        }

        [TestMethod]
        public void GetCalculatedFieldValue_ResultTypeBooleanExpcetion_ReturnsDBNull()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => 1
            }.Instance;
            var fields = new ShimSPFieldCalculated
            {
                CurrencyLocaleIdGet = () => CultureInfo.CurrentCulture.LCID,
                GetFieldValueAsTextObject = valueName => DummyString
            };
            ShimSPField.AllInstances.GetPropertyString = (_, name) => "boolean";
            ShimSPField.AllInstances.InternalNameGet = _ => DummyName;

            // Act
            var result = _EPMData.GetCalculatedFieldValue(listItem, fields);

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldBe(DBNull.Value));
        }

        [TestMethod]
        public void GetCalculatedFieldValue_ResultTypeDummyValue_ReturnsValue()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => 1
            }.Instance;
            var fields = new ShimSPFieldCalculated
            {
                CurrencyLocaleIdGet = () => CultureInfo.CurrentCulture.LCID,
                GetFieldValueAsTextObject = valueName => bool.TrueString
            };
            ShimSPField.AllInstances.GetPropertyString = (_, name) => DummyString;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyName;

            // Act
            var result = _EPMData.GetCalculatedFieldValue(listItem, fields) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void GetCalculatedFieldValue_ResultTypeDummyValueHash_ReturnsValue()
        {
            // Arrange
            var listItem = new ShimSPListItem
            {
                ItemGetString = name => "#1"
            }.Instance;
            var fields = new ShimSPFieldCalculated
            {
                CurrencyLocaleIdGet = () => CultureInfo.CurrentCulture.LCID,
                GetFieldValueAsTextObject = valueName => bool.TrueString
            };
            ShimSPField.AllInstances.GetPropertyString = (_, name) => DummyString;
            ShimSPField.AllInstances.InternalNameGet = _ => DummyName;

            // Act
            var result = _EPMData.GetCalculatedFieldValue(listItem, fields) as string;

            // Assert
            result.ShouldSatisfyAllConditions(
                 () => result.ShouldNotBeNull(),
                 () => result.ShouldNotBeEmpty());
        }

        [TestMethod]
        public void GetSnapshotQueueStatus_DataTableEmpty_FillParameters()
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
            _EPMData.GetSnapshotQueueStatus(out status, out listGuid, out pctComplete, out queued);

            // Assert
            _EPMData.ShouldSatisfyAllConditions(
                () => status.ShouldBe(0),
                () => listGuid.ShouldBeEmpty(),
                () => pctComplete.ShouldBe(0),
                () => queued.ShouldBeFalse());
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
        public void GetSnapshotResults()
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
        public void GetTableNames()
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
