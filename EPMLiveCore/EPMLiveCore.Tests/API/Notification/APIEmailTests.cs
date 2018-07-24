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
        private IDisposable _shims;
        private APIEmail _apiEmail;
        private ShimAPIEmail _apiEmailShim;
        private PrivateObject _apiEmailPrivate;

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
        public void iQueueItemMessage_Called_Disposed()
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

            ShimSPSite.ConstructorGuid = (site, _) =>
            {
                var shimSite = new ShimSPSite(site)
                {
                    OpenWebGuid = webGuid =>
                    {
                        return new ShimSPWeb();
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

            SqlConnection createdConnection = null;
            ShimSqlConnection.ConstructorString = (connection, _) =>
            {
                createdConnection = connection;
            };

            ShimAPIEmail.GetCoreInformationSqlConnectionInt32StringOutStringOutSPWebSPUser =
                (SqlConnection cn, int templateid, out string body, out string subject, SPWeb web, SPUser curUser) =>
                {
                    body = "goose live in {building} house";
                    subject = string.Empty;
                };

            SqlConnection openedConnection = null;
            ShimSqlConnection.AllInstances.Open = connection =>
            {
                openedConnection = connection;
            };

            SqlConnection closedConnection = null;
            ShimSqlConnection.AllInstances.Close = (connection) =>
            {
                closedConnection = connection;
            };

            SqlConnection disposedConnection = null;
            ShimSqlConnection.AllInstances.DisposeBoolean = (connection, disposing) =>
            {
                disposedConnection = connection;
            };

            var createdCommands = new List<SqlCommand>();
            ShimSqlCommand.ConstructorStringSqlConnection = (command, text, conn) =>
            {
                command.Connection = conn;
                command.CommandText = text;
                createdCommands.Add(command);
            };
            ShimSqlCommand.Constructor = command =>
            {
                createdCommands.Add(command);
            };

            var executeReaderCommandsCalled = new List<SqlCommand>();
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                executeReaderCommandsCalled.Add(command);

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

            var executeNonQueryCommands = new List<SqlCommand>();
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                executeNonQueryCommands.Add(command);
                return 0;
            };

            var disposedCommands = new List<SqlCommand>();
            ShimSqlCommand.AllInstances.DisposeBoolean = (command, disposing) =>
            {
                disposedCommands.Add(command);
            };

            var dataSetCommands = new List<SqlCommand>();
            ShimDbDataAdapter.AllInstances.FillDataSet = (adapter, dataSet) =>
            {
                var command = (SqlCommand)adapter.SelectCommand;
                dataSetCommands.Add(command);

                var userTable = new DataTable();
                userTable.Columns.Add("userid", typeof(string));
                var userRow = userTable.NewRow();
                userRow["userid"] = "177";
                userTable.Rows.Add(userRow);
                dataSet.Tables.Add(userTable);
                return 0;
            };

            // Act
            _apiEmailPrivate.Invoke("iQueueItemMessage", BindingFlags.Static | BindingFlags.NonPublic, arguments);

            // Assert
            Assert.AreSame(createdConnection, openedConnection);
            Assert.AreSame(openedConnection, disposedConnection);

            Assert.AreEqual(1, executeReaderCommandsCalled.Count);
            Assert.AreSame(createdConnection, executeReaderCommandsCalled[0].Connection);
            Assert.AreEqual(CommandType.Text, executeReaderCommandsCalled[0].CommandType);
            Assert.IsTrue(
                "SELECT id from NOTIFICATIONS where listid=@listid and itemid=@itemid and type=@type"
                .Equals(executeReaderCommandsCalled[0].CommandText, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(3, executeReaderCommandsCalled[0].Parameters.Count);

            Assert.AreEqual(5, executeNonQueryCommands.Count);
            Assert.AreSame(createdConnection, executeNonQueryCommands[0].Connection);
            Assert.AreEqual(CommandType.Text, executeNonQueryCommands[0].CommandType);
            Assert.IsTrue(executeNonQueryCommands[0].CommandText.StartsWith("update", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(executeNonQueryCommands[1].CommandText.StartsWith("spNSetBit", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(executeNonQueryCommands[2].CommandText.StartsWith("insert", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(executeNonQueryCommands[3].CommandText.StartsWith("spNSetBit", StringComparison.OrdinalIgnoreCase));
            Assert.IsTrue(executeNonQueryCommands[4].CommandText.StartsWith("delete", StringComparison.OrdinalIgnoreCase));

            Assert.AreEqual(1, dataSetCommands.Count);
            Assert.AreSame(createdConnection, dataSetCommands[0].Connection);
            Assert.AreEqual(CommandType.Text, dataSetCommands[0].CommandType);
            Assert.IsTrue(
                "select * from personalizations where FK=@id"
                .Equals(dataSetCommands[0].CommandText, StringComparison.OrdinalIgnoreCase));
            Assert.AreEqual(1, dataSetCommands[0].Parameters.Count);

            Assert.AreEqual(7, createdCommands.Count);
            Assert.AreEqual(6, disposedCommands.Count);
            Assert.AreSame(createdCommands[1], disposedCommands[0]);
            Assert.AreSame(createdCommands[2], disposedCommands[1]);
            Assert.AreSame(createdCommands[3], disposedCommands[2]);
            Assert.AreSame(createdCommands[4], disposedCommands[3]);
            Assert.AreSame(createdCommands[5], disposedCommands[4]);
            Assert.AreSame(createdCommands[6], disposedCommands[5]);
        }

        private static ShimSPListItem CreateShimSpListItem()
        {
            var id = new Guid("B9298FFB-0304-4A82-A8F0-D9983ED6B869");
            var webAppShim = new ShimSPWebApplication();
            var persistentObject = new ShimSPPersistedObject(webAppShim);
            persistentObject.IdGet = () => id;

            return new ShimSPListItem
            {
                ParentListGet = () =>
                {
                    return new ShimSPList
                    {
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