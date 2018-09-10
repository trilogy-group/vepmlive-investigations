using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Fakes;
using System.Web.UI.Fakes;
using EPMLive.TestFakes.Utility;
using EPMLiveCore.Properties;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Administration.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.WebPageCode
{
    [TestClass]
    public class CreateDatabaseTest
    {
        private const string MethodPageLoad = "Page_Load";
        private const string ApplicationPoolUserName = "ApplicationUserName";
        private const string RequestServer = "Server";
        private const string RequestDb = "Database";
        private const string RequestUserName = "Username";
        private const string RequestPassword = "Password";
        private static readonly string RequestWebApp = Guid.NewGuid().ToString();

        private IDisposable _shimsContext;
        private createdatabase _testEntity;
        private PrivateObject _testEntityPrivate;

        [TestInitialize]
        public void TestInitialize()
        {
            _shimsContext = ShimsContext.Create();
            _testEntity = new createdatabase();
            _testEntityPrivate = new PrivateObject(_testEntity);
        }

        [TestMethod]
        public void PageLoad_WhenCalled_CreatesSqlConnections()
        {
            // Arrange
            const int totalConnectionsCount = 2;
            const string expectedConnectionString01 = "Server=Server;Database=master;User Id=Username;Password=Password";
            const string expectedConnectionString02 = "Server=Server;Database=Database;User Id=Username;Password=Password";

            SetupForPageLoad();
            var adoShims = AdoShims.ShimAdoNetCalls();

            // Act
            _testEntityPrivate.Invoke(MethodPageLoad, this, EventArgs.Empty);

            // Assert
            adoShims.ShouldSatisfyAllConditions(
                () => adoShims.ConnectionsCreated.Count.ShouldBe(totalConnectionsCount),
                () => adoShims.ConnectionsCreated.ShouldContain(item => item.ConnectionString == expectedConnectionString01),
                () => adoShims.ConnectionsCreated.ShouldContain(item => item.ConnectionString == expectedConnectionString02),
                () => adoShims.ConnectionsOpened.Count.ShouldBe(totalConnectionsCount),
                () => adoShims.ConnectionsClosed.Count.ShouldBe(totalConnectionsCount),
                () => adoShims.ConnectionsDisposed.Count.ShouldBe(totalConnectionsCount));
        }

        [TestMethod]
        public void PageLoad_WhenCalled_CreatesSqlCommands()
        {
            // Arrange
            const int totalCommandsCount = 10;
            const string expectedCommandText01 = "CREATE DATABASE Database";
            const string expectedCommandText02 = "create user [ApplicationUserName] from login [ApplicationUserName]";
            const string expectedCommandText03 = "sp_addrolemember";
            const string expectedCommandText04 = "INSERT INTO VERSIONS (VERSION, DTINSTALLED) VALUES (@version, GETDATE())";

            SetupForPageLoad();
            var adoShims = AdoShims.ShimAdoNetCalls();

            // Act
            _testEntityPrivate.Invoke(MethodPageLoad, this, EventArgs.Empty);

            // Assert
            adoShims.ShouldSatisfyAllConditions(
                () => adoShims.CommandsCreated.Count.ShouldBe(totalCommandsCount),
                () => adoShims.CommandsCreated.ShouldContain(item => item.CommandText == expectedCommandText01),
                () => adoShims.CommandsCreated.ShouldContain(item => item.CommandText == expectedCommandText02),
                () => adoShims.CommandsCreated.ShouldContain(item => item.CommandText == expectedCommandText03 &&
                                                                     item.CommandType == CommandType.StoredProcedure),
                () => adoShims.CommandsCreated.ShouldContain(item => item.CommandText == expectedCommandText04),
                () => adoShims.CommandsCreated.ShouldContain(item => item.CommandText == Resources._0Tables01),
                () => adoShims.CommandsCreated.ShouldContain(item => item.CommandText == Resources._0Tables02),
                () => adoShims.CommandsCreated.ShouldContain(item => item.CommandText == Resources._1Views01),
                () => adoShims.CommandsCreated.ShouldContain(item => item.CommandText == Resources._2SPs01),
                () => adoShims.CommandsCreated.ShouldContain(item => item.CommandText == Resources._9Data01),
                () => adoShims.CommandsCreated.ShouldContain(item => item.CommandText == Resources._9Data02),
                () => adoShims.CommandsExecuted.Count.ShouldBe(totalCommandsCount),
                () => adoShims.CommandsDisposed.Count.ShouldBe(totalCommandsCount));
        }

        private void SetupForPageLoad()
        {
            var requestFormCollection = new Dictionary<string, string>()
            {
                ["Server"] = RequestServer,
                ["DB"] = RequestDb,
                ["Username"] = RequestUserName,
                ["Password"] = RequestPassword,
                ["WEBAPP"] = RequestWebApp
            };

            var shimHttpServerUtility = new ShimHttpServerUtility();
            var shimHttpRequest = new ShimHttpRequest();
            shimHttpRequest.ItemGetString =
                key => requestFormCollection.ContainsKey(key)
                       ? requestFormCollection[key]
                       : string.Empty;

            ShimPage.AllInstances.ServerGet = _ => shimHttpServerUtility;
            ShimPage.AllInstances.RequestGet = _ => shimHttpRequest;

            var shimSpApplicationPool = new ShimSPApplicationPool();
            var shimSpProcessIdentity = new ShimSPProcessIdentity(shimSpApplicationPool);
            shimSpProcessIdentity.UsernameGet = () => ApplicationPoolUserName;

            var shimSpWebApplication = new ShimSPWebApplication();
            shimSpWebApplication.ApplicationPoolGet = () => shimSpApplicationPool;

            var shimSpWebApplicationCollection = new ShimSPWebApplicationCollection();
            var shimSpPersistedObjectCollection = new ShimSPPersistedObjectCollection<SPWebApplication>(shimSpWebApplicationCollection);
            shimSpPersistedObjectCollection.ItemGetGuid = _ => shimSpWebApplication;

            var shimSpWebService = new ShimSPWebService();
            shimSpWebService.WebApplicationsGet = () => shimSpWebApplicationCollection;
            ShimSPWebService.ContentServiceGet = () => shimSpWebService;
        }
    }
}
