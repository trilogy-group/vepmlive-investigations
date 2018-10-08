using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlClient.Fakes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Fakes;
using EPMLiveCore.API.Fakes;
using EPMLiveCore.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.SharePoint.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeSheets;


namespace EPMLiveTimesheets.Tests.Jobs
{
    using System.Data;
    using System.Data.Common.Fakes;
    using System.Data.Fakes;
    using Shouldly;
    using TimeSheets.Fakes;

    [TestClass]
    public class SaveJobTests
    {
        private IDisposable shimsContext;
        private SaveJob saveJobs;
        private PrivateObject privateObject;

        private const string DummyString = "DummyString";
        private const int DummyInt = 1;
        private static readonly Guid DummyGuid = Guid.NewGuid();

        [TestInitialize]
        public void Initialize()
        {
            shimsContext = ShimsContext.Create();
            SetupShims();
            saveJobs = new SaveJob();
            privateObject = new PrivateObject(saveJobs);
        }

        [TestCleanup]
        public void Cleanup()
        {
            shimsContext?.Dispose();
        }

        private void SetupShims()
        {
            ShimSPSecurity.RunWithElevatedPrivilegesSPSecurityCodeToRunElevated = code => code();
            ShimSqlConnection.ConstructorString = (_, connectionString) => { };

            ShimCoreFunctions.getConnectionStringGuid = _ => DummyString;
            ShimXmlDocument.AllInstances.LoadXmlString = (_, data) => { };
            ShimSPPersistedObject.AllInstances.IdGet = _ => DummyGuid;
            ShimBaseJob.AllInstances.CreateConnection = _ => new SqlConnection();
            ShimSqlConnection.AllInstances.Open = _ => { };
            ShimDbDataAdapter.AllInstances.FillDataSet = (_, dataSet) => 1;
            ShimSqlCommand.AllInstances.ExecuteNonQuery = _ => 1;
            ShimXmlNode.AllInstances.FirstChildGet = _ => new ShimXmlNode(new ShimXmlDocument());
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection();
            ShimCoreFunctions.getConfigSettingSPWebString = (web, name) => bool.TrueString;
            ShimTimesheetSettings.ConstructorSPWeb = (_, web) => { };
            ShimTimesheetAPI.SubmitTimesheetStringSPWeb = (content, web) => DummyString;

        }



        [TestMethod]
        public void Execute_OnGeneralException_LogError()
        {
            // Arrange
            var expectedErrorMessage = $"Error: {DummyString}";
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = name => new ShimSPList()
                    },
                    AllUsersGet = () => new ShimSPUserCollection
                    {
                        GetByIDInt32 = id => new ShimSPUser()
                    }
                },
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            ShimXmlDocument.AllInstances.LoadXmlString = (_, data) => 
            {
                throw new Exception(DummyString);
            };

            // Act
            saveJobs.execute(spSite, DummyString);

            // Assert
            saveJobs.ShouldSatisfyAllConditions(
                () => saveJobs.sErrors.ShouldNotBeEmpty(),
                () => saveJobs.sErrors.ShouldContain(expectedErrorMessage),
                () => saveJobs.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_ConnectionException_LogError()
        {
            // Arrange
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = name => new ShimSPList()
                    },
                    AllUsersGet = () => new ShimSPUserCollection
                    {
                        GetByIDInt32 = id => new ShimSPUser()
                    }
                },
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            ShimSqlConnection.AllInstances.Open = _ =>
            {
                throw new Exception(DummyString);
            };

            // Act
            saveJobs.execute(spSite, DummyString);

            // Assert
            saveJobs.ShouldSatisfyAllConditions(
                () => saveJobs.sErrors.ShouldNotBeEmpty(),
                () => saveJobs.sErrors.ShouldContain(DummyString),
                () => saveJobs.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_TimesheetDoestNotExist_LogError()
        {
            // Arrange
            const string ExpectedErrorMessage = "Timesheet does not exist";
            var sqlCommandList = new List<string>();
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = name => new ShimSPList()
                    },
                    AllUsersGet = () => new ShimSPUserCollection
                    {
                        GetByIDInt32 = id => new ShimSPUser()
                    }
                },
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            ShimTimesheetAPI.GetUserSPWebString = (web, name) => new ShimSPUser
            {
                IDGet = () => 10
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => false,
                GetInt32Int32 = index => DummyInt,
                GetStringInt32 = index => DummyString
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommandList.Add(command.CommandText);
                return 1;
            };

            // Act
            saveJobs.execute(spSite, DummyString);

            // Assert
            saveJobs.ShouldSatisfyAllConditions(
                () => saveJobs.sErrors.ShouldNotBeEmpty(),
                () => saveJobs.sErrors.ShouldContain(ExpectedErrorMessage),
                () => saveJobs.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_UserDoesNotHavePermission_LogError()
        {
            // Arrange
            const string ExpectedErrorMessage = "You do not have access to edit that timesheet.";
            var sqlCommandList = new List<string>();
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = name => new ShimSPList()
                    },
                    AllUsersGet = () => new ShimSPUserCollection
                    {
                        GetByIDInt32 = id => new ShimSPUser()
                    }
                },
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            ShimTimesheetAPI.GetUserSPWebString = (web, name) => new ShimSPUser
            {
                IDGet = () => 10
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                GetInt32Int32 = index => DummyInt,
                GetStringInt32 = index => DummyString
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommandList.Add(command.CommandText);
                return 1;
            };

            // Act
            saveJobs.execute(spSite, DummyString);

            // Assert
            saveJobs.ShouldSatisfyAllConditions(
                () => saveJobs.sErrors.ShouldNotBeEmpty(),
                () => saveJobs.sErrors.ShouldContain(ExpectedErrorMessage),
                () => saveJobs.bErrors.ShouldBeTrue());
        }

        [TestMethod]
        public void Execute_OnSuccess_ExecutesCorrectly()
        {
            // Arrange
            var processResourcesWasCalled = false;
            var submitTimesheetWasCalled = false;
            var sqlCommandList = new List<string>();
            var spSite = new ShimSPSite
            {
                RootWebGet = () => new ShimSPWeb
                {
                    ListsGet = () => new ShimSPListCollection
                    {
                        ItemGetString = name => new ShimSPList()
                    },
                    AllUsersGet = () => new ShimSPUserCollection
                    {
                        GetByIDInt32 = id => new ShimSPUser()
                    }
                },
                WebApplicationGet = () => new ShimSPWebApplication()
            };
            ShimTimesheetAPI.GetUserSPWebString = (web, name) => new ShimSPUser
            {
                IDGet = () => DummyInt
            };
            ShimDataSet.AllInstances.TablesGet = _ => new ShimDataTableCollection
            {
                ItemGetInt32 = index => new DataTable()
            };
            ShimSqlCommand.AllInstances.ExecuteReader = _ => new ShimSqlDataReader
            {
                Read = () => true,
                GetInt32Int32 = index => DummyInt,
                GetStringInt32 = index => DummyString
            };
            ShimXmlNode.AllInstances.AttributesGet = _ => new ShimXmlAttributeCollection
            {
                ItemOfGetString = name => new ShimXmlAttribute()
                {
                    ValueGet = () => bool.TrueString
                }
            };
            ShimXmlNode.AllInstances.SelectNodesString = (_, node) =>
            {
                var doc = new XmlDocument();
                var element = doc.CreateElement(DummyString);
                doc.AppendChild(element);
                return doc.ChildNodes;
            };
            ShimDataTable.AllInstances.RowsGet = _ => new ShimDataRowCollection
            {
                GetEnumerator = () => new List<DataRow>
                {
                    new ShimDataRow
                    {
                        ItemGetString = name => DummyString
                    }
                }.GetEnumerator()
            };
            ShimSharedFunctions.processResourcesSqlConnectionStringSPWebString = (connection, id, web, username) => 
            {
                processResourcesWasCalled = true;
            };
            ShimTimesheetAPI.SubmitTimesheetStringSPWeb = (content, web) =>
            {
                submitTimesheetWasCalled = true;
                return DummyString;
            };
            ShimSqlCommand.AllInstances.ExecuteNonQuery = command =>
            {
                sqlCommandList.Add(command.CommandText);
                return 1;
            };
            ShimSaveJob.AllInstances.ProcessItemRowXmlNodeDataTableRefSqlConnectionSPSiteTimesheetSettingsStringStringBooleanBoolean = ProcessItemRow;

            // Act
            saveJobs.execute(spSite, DummyString);

            // Assert
            saveJobs.ShouldSatisfyAllConditions(
                () => saveJobs.sErrors.ShouldBeEmpty(),
                () => saveJobs.bErrors.ShouldBeFalse(),
                () => processResourcesWasCalled.ShouldBeTrue(),
                () => submitTimesheetWasCalled.ShouldBeTrue(),
                () => GetExpectedSqlCommands().All(p => sqlCommandList.Contains(p)));
        }

        private List<string> GetExpectedSqlCommands()
        {
            return new List<string>
            {
                "UPDATE TSTIMESHEET SET LASTMODIFIEDBYU=@uname, LASTMODIFIEDBYN=@name where TS_UID=@tsuid",
                "SELECT * FROM TSITEM WHERE TS_UID=@tsuid",
                "SELECT period_id FROM TSTIMESHEET WHERE TS_UID=@tsuid",
                "update TSQUEUE set percentcomplete=@pct where TSQUEUE_ID=@QueueUid",
                "update TSQUEUE set percentcomplete=98 where TSQUEUE_ID=@QueueUid",
                "DELETE FROM TSITEM where TS_ITEM_UID=@uid",
                "update TSQUEUE set percentcomplete=99 where TSQUEUE_ID=@QueueUid",
                "INSERT INTO TSQUEUE (TS_UID, STATUS, JOBTYPE_ID, USERID, JOBDATA) VALUES (@tsuid, 0, 32, @userid, @jobdata)"
            };
        }

        private void ProcessItemRow(SaveJob instance, XmlNode ndRow, ref DataTable dtItems, SqlConnection cn, SPSite site, TimesheetSettings settings, string period, string username, bool liveHours, bool bSkipSP)
        {
            dtItems = new DataTable();
        }
    }
}
