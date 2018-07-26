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

namespace EPMLiveCore.Tests.API.Notification
{
    [TestClass]
    public class APIEmailTests
    {
        private const int ListItemId = 711;
        private static readonly Guid _listParentListId = new Guid("19EDE34A-5358-48B6-B468-E3FECA86E1E6");

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

        [TestInitialize]
        public void TestInitialize()
        {
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
            var spListItem = CreateShimSpListItem();

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
                (SPListItem)CreateShimSpListItem(),
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
                        return new ShimSPWeb
                        {
                            IDGet = () => Guid.NewGuid(),
                            SiteGet = () => new ShimSPSite
                            {
                                IDGet = () => Guid.NewGuid()
                            }
                        };
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

        private static ShimSPListItem CreateShimSpListItem()
        {
            var id = new Guid("B9298FFB-0304-4A82-A8F0-D9983ED6B869");
            var webAppShim = new ShimSPWebApplication();
            var persistentObject = new ShimSPPersistedObject(webAppShim);
            persistentObject.IdGet = () => id;

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