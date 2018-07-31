using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Reflection;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EPMLiveCore.Tests.API.Notification
{
    [TestClass]
    public class APIEmailTests
    {
        private const int ListItemId = 711;
        private static readonly Guid _listParentListId = new Guid("19EDE34A-5358-48B6-B468-E3FECA86E1E6");
        private static readonly Guid _webId = new Guid("8EB90CFE-34EA-4383-89DF-B04F8A2C29A9");
        private static readonly Guid _oWebId = new Guid("C93098C4-2B5A-4ABC-9D7A-080DCF4A55A7");
        private const int ItemId = 229;
        private const string ListId = "9BDC6F65-7849-49D7-946D-9B5C1D3B83B3";
        private const string ListName = "Goose";
        private static readonly Guid _webAppGuid1 = new Guid("B9298FFB-0304-4A82-A8F0-D9983ED6B869");
        private static readonly Guid _webAppGuid2 = new Guid("B7B3D541-D097-4940-A69E-A1302BFBB350");
        private static readonly Guid _webAppGuid3 = new Guid("8BD93B95-2847-4EF6-97EE-136E08905304");
        private static readonly Guid _webAppGuid4 = new Guid("F1235BCE-3F68-4805-B730-21F82120B75A");
        private static readonly string SpId = "1122";

        private IDisposable _shims;
        private APIEmail _apiEmail;
        private ShimAPIEmail _apiEmailShim;
        private PrivateObject _apiEmailPrivate;
        private SqlConnection _createdConnection;
        private SqlConnection _openedConnection;
        private SqlConnection _closedConnection;
        private SqlConnection _disposedConnection;
        private List<SqlCommand> _createdCommands;
        private List<SqlCommand> _executeReaderCommandsCalled;
        private List<SqlCommand> _executeNonQueryCommands;
        private List<SqlCommand> _disposedCommands;
        private List<SqlCommand> _dataSetCommands;
        private SPListItem _spListItemCalledXml;
        private int _calledTemplateId;
        private bool _calledHideFromUser;
        private Hashtable _calledAdditionalParams;
        private string[] _calledNewUsers;
        private string[] _calledDelUsers;
        private bool _calledDoNotEmail;
        private bool _calledUnmarkread;

        [TestInitialize]
        public void TestInitialize()
        {
            _spListItemCalledXml = null;
            _shims = ShimsContext.Create();
            ShimAPIEmail.Constructor = apiEmail =>
            {
                _apiEmailShim = new ShimAPIEmail(apiEmail);
            };
            _apiEmail = new APIEmail();
            _apiEmailPrivate = new PrivateObject(_apiEmail);

            ShimCoreFunctions.getConnectionStringGuid = _ =>
            {
                return null;
            };

            ShimIQueueItemMessage();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shims?.Dispose();
        }

        [TestMethod]
        public void ClearNotificationItem_Called_ObjectDisposed()
        {
            // Arrange
            var spListItem = CreateShimSpListItem(_webAppGuid1);

            SqlConnection createdConnection = null;
            ShimSqlConnection.ConstructorString = (connection, _) =>
            {
                createdConnection = connection;
            };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action =>
            {
                action();
            };

            SqlConnection openedConnection = null;
            ShimSqlConnection.AllInstances.Open = connection =>
            {
                openedConnection = connection;
            };

            SqlCommand executedCommand = null;
            string executedSpName = null;
            CommandType? executedCommandType = null;
            SqlConnection executedCommandConnection = null;
            SqlParameterCollection executedParams = null;

            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executedCommandConnection = command.Connection;
                executedSpName = command.CommandText;
                executedCommandType = command.CommandType;
                executedParams = command.Parameters;
                executedCommand = command;
                return 0;
            };

            SqlConnection disposedConnection = null;
            ShimSqlConnection.AllInstances.DisposeBoolean = (connection, disposing) =>
            {
                disposedConnection = connection;
            };

            SqlCommand disposedCommand = null;
            ShimSqlCommand.AllInstances.DisposeBoolean = (command, disposing) =>
            {
                disposedCommand = command;
            };

            // Act
            APIEmail.ClearNotificationItem(spListItem);

            // Assert
            Assert.AreSame(createdConnection, openedConnection);
            Assert.IsNotNull(executedCommand);
            Assert.AreEqual("spNDeleteNotification", executedSpName);
            Assert.AreEqual(CommandType.StoredProcedure, executedCommandType);
            Assert.AreEqual(2, executedParams.Count);
            Assert.AreEqual("@listid", executedParams[0].ParameterName);
            Assert.AreEqual("@itemid", executedParams[1].ParameterName);
            Assert.AreSame(executedCommand, disposedCommand);
        }

        [TestMethod]
        public void iQueueItemMessage1_Called_Disposed()
        {
            // Arrange
            var shimUser = new ShimSPUser();

            var arguments = new object[]
            {
                1,
                true,
                new Hashtable()
                {
                    { "building", "64" }
                },
                new string[] { "177", "401" },
                new string[] { "919" },
                true,
                true,
                (SPListItem)CreateShimSpListItem(_webAppGuid1),
                (SPUser)shimUser,
                false
            };

            // Act
            _apiEmailPrivate.Invoke("iQueueItemMessage", BindingFlags.Static | BindingFlags.NonPublic, arguments);

            // Assert
            AssetConnection();

            Assert.AreEqual(1, _executeReaderCommandsCalled.Count);
            Assert.AreSame(_createdConnection, _executeReaderCommandsCalled[0].Connection);
            Assert.AreEqual(CommandType.Text, _executeReaderCommandsCalled[0].CommandType);
            Assert.IsTrue(
                "SELECT id from NOTIFICATIONS where listid=@listid and itemid=@itemid and type=@type"
                .Equals(_executeReaderCommandsCalled[0].CommandText, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(3, _executeReaderCommandsCalled[0].Parameters.Count);
            Assert.AreEqual("@listid", _executeReaderCommandsCalled[0].Parameters[0].ParameterName);
            Assert.AreEqual("@itemid", _executeReaderCommandsCalled[0].Parameters[1].ParameterName);
            Assert.AreEqual("@type", _executeReaderCommandsCalled[0].Parameters[2].ParameterName);

            AssertNonQueryComands(ListItemId, _listParentListId);
            AssertDataSetCommand();

            Assert.AreEqual(7, _createdCommands.Count);
            Assert.AreEqual(6, _disposedCommands.Count);
            Assert.AreSame(_createdCommands[1], _disposedCommands[0]);
            Assert.AreSame(_createdCommands[2], _disposedCommands[1]);
            Assert.AreSame(_createdCommands[3], _disposedCommands[2]);
            Assert.AreSame(_createdCommands[4], _disposedCommands[3]);
            Assert.AreSame(_createdCommands[5], _disposedCommands[4]);
            Assert.AreSame(_createdCommands[6], _disposedCommands[5]);
        }

        [TestMethod]
        public void iQueueItemMessage2_Called_Disposed()
        {
            // Arrange
            var shimUser = new ShimSPUser();
            var arguments = new object[]
            {
                1,
                true,
                new Hashtable()
                {
                    { "building", "64" }
                },
                new string[] { "177", "401" },
                new string[] { "919" },
                true,
                true,
                (SPWeb)CreateSPWeb(),
                (SPUser)shimUser,
                false
            };

            // Act
            _apiEmailPrivate.Invoke("iQueueItemMessage", BindingFlags.Static | BindingFlags.NonPublic, arguments);

            // Assert
            AssetConnection();

            Assert.AreEqual(1, _executeReaderCommandsCalled.Count);
            Assert.AreSame(_createdConnection, _executeReaderCommandsCalled[0].Connection);
            Assert.AreEqual(CommandType.Text, _executeReaderCommandsCalled[0].CommandType);
            Assert.IsTrue(
                "SELECT id from NOTIFICATIONS where webid=@webid and type=@type"
                .Equals(_executeReaderCommandsCalled[0].CommandText, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(2, _executeReaderCommandsCalled[0].Parameters.Count);
            Assert.AreEqual("@webid", _executeReaderCommandsCalled[0].Parameters[0].ParameterName);
            Assert.AreEqual("@type", _executeReaderCommandsCalled[0].Parameters[1].ParameterName);

            AssertNonQueryComands(DBNull.Value, DBNull.Value);
            AssertDataSetCommand();

            Assert.AreEqual(7, _createdCommands.Count);
            Assert.AreEqual(4, _disposedCommands.Count);
            Assert.AreSame(_createdCommands[1], _disposedCommands[0]);
            Assert.AreSame(_createdCommands[2], _disposedCommands[1]);
            Assert.AreSame(_createdCommands[3], _disposedCommands[2]);
            Assert.AreSame(_createdCommands[5], _disposedCommands[3]);
        }

        [TestMethod]
        public void QueueItemMessageXml_ListIdEmpty_OkReturned()
        {
            QueueItemMessageXml_Called_OkReturned(
                ListName, 
                string.Empty, 
                ItemId, 
                _webId.ToString(), 
                _oWebId, 
                _webAppGuid4);
        }

        [TestMethod]
        public void QueueItemMessageXml_ListIdNotEmpty_OkReturned()
        {
            QueueItemMessageXml_Called_OkReturned(
                ListName, 
                ListId, 
                ItemId, 
                _webId.ToString(), 
                _oWebId,
                _webAppGuid3);
        }

        [TestMethod]
        public void QueueItemMessageXml_ListIdEmptyWebIdEmpty_OkReturned()
        {
            QueueItemMessageXml_Called_OkReturned(
                ListName, 
                string.Empty, 
                ItemId, 
                string.Empty, 
                _oWebId, 
                _webAppGuid2);
        }

        [TestMethod]
        public void QueueItemMessageXml_ListIdNotEmptyWebIdEmpty_OkReturned()
        {
            QueueItemMessageXml_Called_OkReturned(
                ListName, 
                ListId,
                ItemId, 
                string.Empty, 
                _oWebId, 
                _webAppGuid1);
        }

        private void QueueItemMessageXml_Called_OkReturned(
            string listName, 
            string listId, 
            int itemId, 
            string webId, 
            Guid oWebId, 
            Guid expectedWebApplicationId)
        {
            // Arrange
            var data = GetXml(listName, listId, itemId, webId);
            var shimSpWeb = new ShimSPWeb
            {
                IDGet = () => oWebId,
                SiteGet = () => new ShimSPSite
                {
                    IDGet = () => Guid.NewGuid()
                }
            };

            ShimAPITeam.GetResourcePoolStringSPWeb = (xml, web) =>
            {
                var table = new DataTable();
                table.Columns.Add("user");
                table.Columns.Add("SPID");
                var row = table.NewRow();
                row["user"] = "valera";
                row["SPID"] = SpId;
                table.Rows.Add(row);
                return table;
            };

            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = action =>
            {
                action();
            };

            ShimQueueItemMessage();

            // Act
            var result = APIEmail.QueueItemMessageXml(data, shimSpWeb);

            // Assert
            Assert.AreEqual(expectedWebApplicationId, _spListItemCalledXml.ParentList.ParentWeb.Site.WebApplication.Id);
            Assert.AreEqual(_calledTemplateId, 17);
            Assert.AreEqual(_calledAdditionalParams["Building"], "64b");
            Assert.IsTrue(new [] { SpId }.SequenceEqual(_calledNewUsers));
            Assert.IsTrue(new[] { "vladislav", "vitaliy" }.SequenceEqual(_calledDelUsers));
            Assert.IsTrue(_calledDoNotEmail);
            Assert.IsTrue(_calledUnmarkread);
        }

        private void ShimQueueItemMessage()
        {
            ShimAPIEmail
                .QueueItemMessageInt32BooleanHashtableStringArrayStringArrayBooleanBooleanSPListItemSPUserBoolean
                    = (int templateid,
                        bool hideFromUser,
                        Hashtable additionalParams,
                        string[] newusers,
                        string[] delusers,
                        bool doNotEmail,
                        bool unmarkread,
                        SPListItem listItem,
                        SPUser curUser,
                        bool forceNewEntry) =>
                    {
                        _calledTemplateId = templateid;
                        _calledHideFromUser = hideFromUser;
                        _calledAdditionalParams = additionalParams;
                        _calledNewUsers = newusers;
                        _calledDelUsers = delusers;
                        _calledDoNotEmail = doNotEmail;
                        _calledUnmarkread = unmarkread;
                        _spListItemCalledXml = listItem;
                    };
        }

        private static string GetXml(string listName, string listId, int itemId, string webId)
        {
            return "<Template " +
                            $"TemplateID=\"17\" ListName=\"{listName}\" ListID=\"{listId}\" ItemID=\"{itemId}\" WebID=\"{webId}\" " +
                            "HideFromUser=\"True\" DoNotEmail=\"True\" UnMarkRead=\"True\" ForceNewEntry=\"True\" " +
                            "NewUsers=\"valera,george\" " +
                            "RemoveUsers=\"vladislav,vitaliy\" " +
                            "ExternalColumn=\"user\" >" +
                            "<Params>" +
                            "<Param Name=\"Building\">64b</Param>" +
                            "</Params>" +
                            "</Template>";
        }

        private void AssetConnection()
        {
            Assert.AreSame(_createdConnection, _openedConnection);
            Assert.AreSame(_openedConnection, _disposedConnection);
        }

        private void AssertNonQueryComands(object listItemId, object listParentListId)
        {
            Assert.AreEqual(5, _executeNonQueryCommands.Count);
            Assert.AreSame(_createdConnection, _executeNonQueryCommands[0].Connection);
            Assert.AreEqual(CommandType.Text, _executeNonQueryCommands[0].CommandType);
            Assert.IsTrue(_executeNonQueryCommands[0].CommandText.StartsWith("update", StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(listParentListId, _executeNonQueryCommands[0].Parameters["@listid"].Value);
            Assert.AreEqual(listItemId, _executeNonQueryCommands[0].Parameters["@itemid"].Value);
            Assert.IsTrue(_executeNonQueryCommands[1].CommandText.StartsWith("spNSetBit", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(_executeNonQueryCommands[2].CommandText.StartsWith("insert", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(_executeNonQueryCommands[3].CommandText.StartsWith("spNSetBit", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(_executeNonQueryCommands[4].CommandText.StartsWith("delete", StringComparison.OrdinalIgnoreCase));
        }

        private void AssertDataSetCommand()
        {
            Assert.AreEqual(1, _dataSetCommands.Count);
            Assert.AreSame(_createdConnection, _dataSetCommands[0].Connection);
            Assert.AreEqual(CommandType.Text, _dataSetCommands[0].CommandType);
            Assert.IsTrue(
                "select * from personalizations where FK=@id"
                .Equals(_dataSetCommands[0].CommandText, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(1, _dataSetCommands[0].Parameters.Count);
        }

        private void ShimIQueueItemMessage()
        {
            ShimSPSite.ConstructorGuid = (site, _) =>
            {
                var shimSite = new ShimSPSite(site)
                {
                    OpenWebGuid = webGuid =>
                    {
                        if (webGuid == _oWebId)
                        {
                            return new ShimSPWeb
                            {
                                IDGet = () => Guid.NewGuid(),
                                SiteGet = () => new ShimSPSite
                                {
                                    IDGet = () => Guid.NewGuid()
                                },
                                ListsGet = () => new ShimSPListCollection
                                {
                                    ItemGetGuid = key =>
                                    {
                                        if (key == new Guid(ListId))
                                        {
                                            return new ShimSPList
                                            {
                                                GetItemByIdInt32 = id =>
                                                {
                                                    if (id == ItemId)
                                                    {
                                                        return CreateShimSpListItem(_webAppGuid1);
                                                    }
                                                    return null;
                                                }
                                            };
                                        }
                                        else
                                        {
                                            return null;
                                        }
                                    },
                                    TryGetListString = key => 
                                    {
                                        if (key == ListName)
                                        {
                                            return new ShimSPList
                                            {
                                                GetItemByIdInt32 = id =>
                                                {
                                                    if (id == ItemId)
                                                    {
                                                        return CreateShimSpListItem(_webAppGuid2);
                                                    }
                                                    return null;
                                                }
                                            };
                                        }
                                        else
                                        {
                                            return null;
                                        }
                                    }
                                }
                            };
                        }
                        else
                        {
                            return new ShimSPWeb
                            {
                                IDGet = () => Guid.NewGuid(),
                                SiteGet = () => new ShimSPSite
                                {
                                    IDGet = () => Guid.NewGuid()
                                },
                                ListsGet = () => new ShimSPListCollection
                                {
                                    ItemGetGuid = key =>
                                    {
                                        if (key == new Guid(ListId))
                                        {
                                            return new ShimSPList
                                            {
                                                GetItemByIdInt32 = id =>
                                                {
                                                    if (id == ItemId)
                                                    {
                                                        return CreateShimSpListItem(_webAppGuid3);
                                                    }
                                                    return null;
                                                }
                                            };
                                        }
                                        else
                                        {
                                            return null;
                                        }
                                    },
                                    TryGetListString = key =>
                                    {
                                        if (key == ListName)
                                        {
                                            return new ShimSPList
                                            {
                                                GetItemByIdInt32 = id =>
                                                {
                                                    if (id == ItemId)
                                                    {
                                                        return CreateShimSpListItem(_webAppGuid4);
                                                    }
                                                    return null;
                                                }
                                            };
                                        }
                                        else
                                        {
                                            return null;
                                        }
                                    }
                                }
                            };
                        }
                    },
                    WebApplicationGet = () =>
                    {
                        var shimSPWebApplication = new ShimSPWebApplication();
                        var shimSPWebApplicationPersistedObject = new ShimSPPersistedObject(shimSPWebApplication)
                        {
                            IdGet = () => Guid.NewGuid()
                        };
                        return shimSPWebApplication;
                    }
                };
            };

            _createdConnection = null;
            ShimSqlConnection.ConstructorString = (connection, _) =>
            {
                _createdConnection = connection;
            };

            ShimGetCoreInformation();

            _openedConnection = null;
            ShimSqlConnection.AllInstances.Open = connection =>
            {
                _openedConnection = connection;
            };

            _closedConnection = null;
            ShimSqlConnection.AllInstances.Close = (connection) =>
            {
                _closedConnection = connection;
            };

            _disposedConnection = null;
            ShimSqlConnection.AllInstances.DisposeBoolean = (connection, disposing) =>
            {
                _disposedConnection = connection;
            };

            _createdCommands = new List<SqlCommand>();
            ShimSqlCommand.ConstructorStringSqlConnection = (command, text, conn) =>
            {
                command.Connection = conn;
                command.CommandText = text;
                _createdCommands.Add(command);
            };
            ShimSqlCommand.Constructor = command =>
            {
                _createdCommands.Add(command);
            };

            _executeReaderCommandsCalled = new List<SqlCommand>();
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                _executeReaderCommandsCalled.Add(command);

                var shimReader = new ShimSqlDataReader
                {
                    Read = () =>
                    {
                        return true;
                    },
                    GetGuidInt32 = _ =>
                    {
                        var readerGuid = new Guid("E2954076-F6FD-4FFE-9B10-642C9D08368F");
                        return readerGuid;
                    }
                };
                return shimReader;
            };

            _executeNonQueryCommands = new List<SqlCommand>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                _executeNonQueryCommands.Add(command);
                return 0;
            };

            _disposedCommands = new List<SqlCommand>();
            ShimSqlCommand.AllInstances.DisposeBoolean = (command, disposing) =>
            {
                _disposedCommands.Add(command);
            };

            _dataSetCommands = new List<SqlCommand>();
            ShimDbDataAdapter.AllInstances.FillDataSet = (adapter, dataSet) =>
            {
                var command = (SqlCommand)adapter.SelectCommand;
                _dataSetCommands.Add(command);

                var userTable = new DataTable();
                userTable.Columns.Add("userid", typeof(string));
                var userRow = userTable.NewRow();
                userRow["userid"] = "177";
                userTable.Rows.Add(userRow);
                dataSet.Tables.Add(userTable);
                return 0;
            };
        }

        private static void ShimGetCoreInformation()
        {
            ShimAPIEmail.GetCoreInformationSqlConnectionInt32StringOutStringOutSPWebSPUser =
                (SqlConnection cn, int templateid, out string body, out string subject, SPWeb web, SPUser curUser) =>
                {
                    body = "goose live in {building} house";
                    subject = string.Empty;
                };
        }

        private static ShimSPWeb CreateSPWeb()
        {
            return new ShimSPWeb
            {
                IDGet = () => Guid.NewGuid(),
                SiteGet = () =>
                {
                    return new ShimSPSite
                    {
                        IDGet = () => Guid.NewGuid()
                    };
                }
            };
        }

        private static ShimSPListItem CreateShimSpListItem(Guid webApplicationId)
        {
            var webAppShim = new ShimSPWebApplication();
            var persistentObject = new ShimSPPersistedObject(webAppShim);
            persistentObject.IdGet = () => webApplicationId;

            return new ShimSPListItem
            {
                IDGet = () => ListItemId,
                ParentListGet = () =>
                {
                    return new ShimSPList
                    {
                        IDGet = () => _listParentListId,
                        ParentWebGet = () =>
                        {
                            return new ShimSPWeb
                            {
                                SiteGet = () =>
                                {
                                    return new ShimSPSite
                                    {
                                        WebApplicationGet = () =>
                                        {
                                            return webAppShim;
                                        }
                                    };
                                }
                            };
                        },
                        FormsGet = () =>
                        {
                            var formCollection = new ShimSPFormCollection
                            {
                                ItemGetPAGETYPE = formId =>
                                {
                                    return new ShimSPForm
                                    {
                                        UrlGet = () =>
                                        {
                                            return "valera.com";
                                        }
                                    };
                                }
                            };
                            return formCollection;
                        }
                    };
                }
            };
        }
    }
}