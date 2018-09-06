using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics;
using System.Diagnostics.Fakes;
using System.Globalization;
using System.IO;
using System.IO.Fakes;
using System.Text;
using System.Web.UI.WebControls;
using EPMLiveCore.API;
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
        public void Constructor_GuidGuidBool_ShouldCreateInstance()
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
                () => databaseName.ShouldNotBeNullOrEmpty(),
                () => databaseServer.ShouldNotBeNullOrEmpty());
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
    }
}
