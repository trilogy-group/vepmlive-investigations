using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common.Fakes;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Fakes;
using System.Net.Mail;
using System.Net.Mail.Fakes;
using System.Text;
using EPMLiveCore.API;
using EPMLiveCore.API.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.API
{
    /// <summary>
    /// Unit Tests for <see cref="EPMLiveCore.API.APIEmail"/>
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class APIEmailTest
    {
        private const int DummyInt = 1;
        private const string DummyString = "DummyString";
        private const string DummyEmail = "dummy@dummy.com";
        private const string DummyUrl = "http://www.dummyurl.com";
        private PrivateType _privateType;
        private PrivateObject _privateObject;
        private APIEmail _testEntity;
        private IDisposable _shimsContext;
        private readonly StringBuilder query = new StringBuilder();
        private readonly StringBuilder functionsInvoked = new StringBuilder();
        private int currentDataReaderCount;
        private int maxDatareaderCount;
        private int DataReaderResult = 0;
        private MailMessage mailMessage;

        // Function Names
        private const string QueueItemMessageXml = "QueueItemMessageXml";
        private const string iQueueItemMessage = "iQueueItemMessage";
        private const string iSendEmail = "iSendEmail";
        private const string sendEmail = "sendEmail";
        private const string InstallAssignedToEvent = "InstallAssignedToEvent";
        private const string GetCoreInformation = "GetCoreInformation";
        private const string UnInstallAssignedToEvent = "UnInstallAssignedToEvent";
        private const string ClearNotificationItem = "ClearNotificationItem";

        [TestInitialize]
        public void SetUp()
        {
            _shimsContext = ShimsContext.Create();

            InitShims();
            query.Clear();
            functionsInvoked.Clear();
            maxDatareaderCount = 1;
            currentDataReaderCount = 0;

            _testEntity = new APIEmail();
            _privateObject = new PrivateObject(_testEntity);
            _privateType = new PrivateType(typeof(APIEmail));
        }

        [TestCleanup]
        public void TearDown()
        {
            _shimsContext?.Dispose();
        }

        [TestMethod]
        public void QueueItemMessageXml_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var xmlString = $@"<dummy TemplateID='{DummyInt.ToString()}' ExternalColumn='{DummyString}' NewUsers='{DummyString},{DummyString}' ItemID='{DummyString}' ListID='{DummyString}' ListName='{DummyString}'>
                                    <Params>
                                        <Param Name='{DummyString}'>{DummyString}</Param>
                                    </Params>
                                </dummy>";
            var parameters = new object[] { xmlString, new ShimSPWeb().Instance };
            ShimAPITeam.GetResourcePoolStringSPWeb = (_, _1) =>
            {
                functionsInvoked.Append("\nAPITeam.GetResourcePool");
                var dataTable = new DataTable();
                dataTable.Columns.Add(DummyString);
                dataTable.Columns.Add("SPID");
                dataTable.Rows.Add(DummyString, DummyString);
                return dataTable;
            };
            var expectedResult = "<Result Status=\"1\"><Error ID=\"30010\">Error: No Item Id specificied</Error></Result>";

            // Act
            var result = _privateType.InvokeStatic(
                QueueItemMessageXml,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => functionsInvoked.ToString().ShouldContain("APITeam.GetResourcePool"),
                () => result.ShouldBe(expectedResult));
        }

        [TestMethod]
        public void iQueueItemMessage_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[]
            {
                DummyInt,
                false,
                new Hashtable()
                {
                    [DummyString] = DummyString,
                },
                new string[]
                {
                    DummyString
                },
                new string[]
                {
                    DummyString
                },
                true,
                true,
                new ShimSPListItem()
                {
                    ParentListGet = () => new ShimSPList()
                    {
                        ParentWebGet = () => new ShimSPWeb()
                        {
                            IDGet = () => new Guid(),
                            SiteGet = () => new ShimSPSite()
                            {
                                IDGet = () => new Guid(),
                            }.Instance,
                        }.Instance,
                        FormsGet = () =>
                        {
                            return new ShimSPFormCollection()
                            {
                                ItemGetPAGETYPE = index =>
                                {
                                    return new ShimSPForm()
                                    {
                                        UrlGet = () => DummyString,
                                    }.Instance;
                                },
                            }.Instance;
                        }
                    }.Instance,
                }.Instance,
                new ShimSPUser().Instance,
                true
            };
            ShimDbDataAdapter.AllInstances.FillDataSet = (_, _1) =>
            {
                _1 = new DataSet();
                var dataTable = new DataTable();
                dataTable.Columns.Add("userid");
                dataTable.Rows.Add(DummyString);
                _1.Tables.Add(dataTable);
                return DummyInt;
            };
            var expectedQueries = new string[]
            {
                "SELECT id from NOTIFICATIONS where listid=@listid and itemid=@itemid and type=@type",
                "INSERT INTO NOTIFICATIONS (id, title, message, type, createdby, createdat, siteid, webid, listid, itemid, emailed) VALUES (@id, @title, @message, @type, @createdby, GETDATE(), @siteid, @webid, @listid, @itemid, @emailed)",
                "INSERT INTO personalizations (FK, [key], value, userid, siteid, webid, listid, itemid) VALUES (@id, 'Notifications', @value, @userid, @siteid, @webid, @listid, @itemid)",
                "spNSetBit",
                "delete from personalizations where FK=@id and userid=@userid",
            };

            // Act
            var result = _privateType.InvokeStatic(
                iQueueItemMessage,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => functionsInvoked.ToString().ShouldContain("SPSite.OpenWeb"));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void iQueueItemMessage_8thParameterSPWeb_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[]
            {
                DummyInt,
                false,
                new Hashtable()
                {
                    [DummyString] = DummyString,
                },
                new string[]
                {
                    DummyString
                },
                new string[]
                {
                    DummyString
                },
                true,
                true,
                new ShimSPWeb().Instance,
                new ShimSPUser().Instance,
                true
            };
            ShimDbDataAdapter.AllInstances.FillDataSet = (_, _1) =>
            {
                _1 = new DataSet();
                var dataTable = new DataTable();
                dataTable.Columns.Add("userid");
                dataTable.Rows.Add(DummyString);
                _1.Tables.Add(dataTable);
                return DummyInt;
            };
            var expectedQueries = new string[]
            {
                "SELECT id from NOTIFICATIONS where webid=@webid and type=@type",
                "INSERT INTO NOTIFICATIONS (id, title, message, type, createdby, createdat, siteid, webid, listid, itemid, emailed) VALUES (@id, @title, @message, @type, @createdby, GETDATE(), @siteid, @webid, @listid, @itemid, @emailed)",
                "INSERT INTO personalizations (FK, [key], value, userid, siteid, webid, listid, itemid) VALUES (@id, 'Notifications', @value, @userid, @siteid, @webid, @listid, @itemid)",
                "spNSetBit",
                "delete from personalizations where FK=@id and userid=@userid",
            };

            // Act
            var result = _privateType.InvokeStatic(
                iQueueItemMessage,
                parameters);

            // Assert
            var assertions = AssertQueries(expectedQueries);
            assertions.Add(() => functionsInvoked.ToString().ShouldContain("SPSite.OpenWeb"));
            this.ShouldSatisfyAllConditions(assertions.ToArray());
        }

        [TestMethod]
        public void iSendEmail_ParametersGiven_ExceptionThrown()
        {
            // Arrange
            var parameters = new object[]
            {
                DummyInt,
                false,
                new Guid(),
                new Guid(),
                new ShimSPUser().Instance,
                new ShimSPUser().Instance,
                new Hashtable()
                {
                    [DummyString] = DummyString,
                },
            };
            ShimSmtpClient.AllInstances.SendMailMessage = null;

            // Act
            var ex = Should.Throw<Exception>(() => { _privateType.InvokeStatic(iSendEmail, parameters); });

            // Assert
            this.ShouldSatisfyAllConditions(
                () => ex.ShouldBeOfType(typeof(Exception)),
                () => ex.Message.ShouldBe("Failure sending mail."));
        }

        [TestMethod]
        public void sendEmail_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[]
            {
                DummyInt,
                new Hashtable()
                {
                    [DummyString] = DummyString,
                },
                new List<string>() { DummyEmail },
                DummyEmail,
                new ShimSPWeb().Instance,
                false
            };

            // Act
            var result = _privateType.InvokeStatic(
                sendEmail,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => mailMessage.From.Address.ShouldBe(DummyEmail),
                () => mailMessage.To.Count.ShouldBe(1),
                () => mailMessage.Subject.ShouldBe(DummyString),
                () => mailMessage.Body.ShouldBe(DummyString));
        }

        [TestMethod]
        public void InstallAssignedToEvent_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPList().Instance };

            // Act
            var result = _privateType.InvokeStatic(
                InstallAssignedToEvent,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => functionsInvoked.ToString().ShouldContain("SPList.Update"));
        }

        [TestMethod]
        public void GetCoreInformation_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[]
            {
                new ShimSqlConnection().Instance,
                DummyInt,
                DummyString,
                DummyString,
                new ShimSPWeb().Instance,
                new ShimSPUser().Instance,
            };
            ShimAPIEmail.GetCoreInformationSqlConnectionInt32StringOutStringOutSPWebSPUser = null;
            var expectedQuery = "SELECT subject,body from EMAILTEMPLATES where emailid=@id";

            // Act
            var result = _privateType.InvokeStatic(
                GetCoreInformation,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => query.ToString().ShouldContain(expectedQuery));
        }

        [TestMethod]
        public void UnInstallAssignedToEvent_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPList().Instance };

            // Act
            var result = _privateType.InvokeStatic(
                UnInstallAssignedToEvent,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => functionsInvoked.ToString().ShouldContain("SPList.Update"));
        }

        [TestMethod]
        public void ClearNotificationItem_ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[] { new ShimSPListItem().Instance };

            // Act
            var result = _privateType.InvokeStatic(
                ClearNotificationItem,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => query.ToString().ShouldContain("spNDeleteNotification"));
        }

        [TestMethod]
        public void sendEmail_3ParametersGiven_CheckBehaviour()
        {
            // Arrange
            var parameters = new object[]
            {
                DummyInt,
                DummyInt,
                new Hashtable()
                {
                    [DummyString] = DummyString,
                },
            };

            // Act
            var result = _privateType.InvokeStatic(
                sendEmail,
                parameters);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => functionsInvoked.ToString().ShouldContain("SPUserCollection.GetByID"),
                () => functionsInvoked.ToString().ShouldContain("SPSite.OpenWeb"),
                () => functionsInvoked.ToString().ShouldContain("SmtpClient.SendMail"));
        }

        private void InitShims()
        {
            ShimSPWeb.AllInstances.SiteUsersGet = _ => new ShimSPUserCollection().Instance;
            ShimSPUserCollection.AllInstances.GetByIDInt32 = (_, _1) =>
            {
                functionsInvoked.Append("\nSPUserCollection.GetByID");
                return new ShimSPUser().Instance;
            };
            ShimSPList.AllInstances.ParentWebGet = _ => new ShimSPWeb().Instance;
            ShimSPListItem.AllInstances.ParentListGet = _ => new ShimSPList().Instance;
            ShimSPWeb.AllInstances.TitleGet = _ => DummyString;
            ShimSPWeb.AllInstances.UrlGet = _ => DummyUrl;
            ShimSPUser.AllInstances.LoginNameGet = _ => DummyEmail;
            ShimSPList.AllInstances.Update = _ =>
            {
                functionsInvoked.Append("\nSPList.Update");
            };
            var sPEventReceiverDefinitionCollection = new List<SPEventReceiverDefinition>()
            {
                new ShimSPEventReceiverDefinition()
                {
                    ClassGet = () => DummyString,
                    AssemblyGet = () => DummyString,
                }.Instance,
            };
            ShimSPBaseCollection.AllInstances.GetEnumerator = _ => sPEventReceiverDefinitionCollection.GetEnumerator();
            ShimSPEventReceiverDefinitionCollection.AllInstances.CountGet = _ => sPEventReceiverDefinitionCollection.Count;
            ShimSPList.AllInstances.EventReceiversGet = _ =>
            {
                return new ShimSPEventReceiverDefinitionCollection().Instance;
            };
            ShimSPUser.AllInstances.NameGet = _ => DummyString;
            ShimSPUser.AllInstances.EmailGet = _ => DummyEmail;
            ShimSPWeb.AllInstances.CurrentUserGet = _ => new ShimSPUser();
            ShimSPContext.AllInstances.WebGet = _ => new ShimSPWeb().Instance;
            ShimSPContext.AllInstances.SiteGet = _ => new ShimSPSite().Instance;
            ShimSPContext.CurrentGet = () => new ShimSPContext().Instance;
            ShimSmtpClient.AllInstances.SendMailMessage = (_, _1) =>
            {
                functionsInvoked.Append("\nSmtpClient.SendMail");
                mailMessage = new MailMessage();
                mailMessage = _1;
            };
            ShimSPUser.AllInstances.EmailGet = _ => DummyEmail;
            ShimSPUser.AllInstances.NameGet = _ => DummyString;
            ShimSPServer.AllInstances.AddressGet = _ => DummyString;
            ShimSPWebApplication.AllInstances.OutboundMailServiceInstanceGet = _ => new SPOutboundMailServiceInstance();
            ShimSPServiceInstance.AllInstances.ServerGet = _ => new ShimSPServer().Instance;
            ShimSPAdministrationWebApplication.LocalGet = () => new ShimSPAdministrationWebApplication().Instance;
            ShimAPIEmail.GetCoreInformationSqlConnectionInt32StringOutStringOutSPWebSPUser = (SqlConnection cn, int templateid, out string body, out string subject, SPWeb web, SPUser curUser) =>
            {
                body = DummyString;
                subject = DummyString;
            };
            ShimSPWeb.AllInstances.SiteGet = _ => new ShimSPSite().Instance;
            ShimSPSite.AllInstances.IDGet = _ => new Guid();
            ShimSPWeb.AllInstances.UrlGet = _ => DummyString;
            ShimSPSite.AllInstances.OpenWebGuid = (_, _1) =>
            {
                functionsInvoked.Append("\nSPSite.OpenWeb");
                return new ShimSPWeb().Instance;
            };
            ShimSPSite.AllInstances.WebApplicationGet = _ =>
            {
                return new ShimSPWebApplication()
                {

                }.Instance;
            };
            ShimSPPersistedObject.AllInstances.IdGet = _ =>
            {
                return new Guid();
            };
            ShimSPSite.ConstructorGuid = (_, _1) => { };
            ShimDateTime.NowGet = () => new DateTime(2010, 10, 10, 10, 10, 10);
            SetupSqlShims();
        }

        private void SetupSqlShims()
        {
            ShimSqlConnection.AllInstances.StateGet = _ => System.Data.ConnectionState.Open;
            ShimSqlConnection.ConstructorString = (_, _1) => { };
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimSqlConnection.AllInstances.Close = _ => { };
            ShimSqlCommand.AllInstances.ExecuteScalar = command =>
            {
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                query.Append("\n" + command.CommandText);
                return DummyInt;
            };
            ShimSqlCommand.AllInstances.ExecuteReader = command =>
            {
                query.AppendLine(command.CommandText);
                return new ShimSqlDataReader()
                {
                    Close = () => currentDataReaderCount = 0,
                    Read = () =>
                    {
                        currentDataReaderCount++;
                        return currentDataReaderCount <= maxDatareaderCount;
                    },
                    GetSqlInt32Int32 = indx => DummyInt,
                    GetStringInt32 = _ => DummyString,
                    ItemGetString = key =>
                    {
                        DataReaderResult++;
                        if (key.Contains("TIMESTAMP") || key.Contains("DATE"))
                        {
                            return DateTime.Now;
                        }
                        return DataReaderResult;
                    },
                }.Instance;
            };
        }

        private List<Action> AssertQueries(string[] expectedQueries)
        {
            var assertions = new List<Action>();
            foreach (var expectedQuery in expectedQueries)
            {
                assertions.Add(() => query.ToString().ShouldContain(expectedQuery));
            }
            return assertions;
        }
    }
}
